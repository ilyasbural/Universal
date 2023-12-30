namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserCertificateManager : BusinessObject<UserCertificate>, IUserCertificateService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserCertificate> Validator;

        public UserCertificateManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserCertificate> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserCertificate>> InsertAsync(UserCertificateRegisterDto Model)
        {
            Data = Mapper.Map<UserCertificate>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserCertificate>(Data);
            await UnitOfWork.UserCertificate.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserCertificate>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserCertificate>> SelectAsync()
        {
            Collection = await UnitOfWork.UserCertificate.SelectAsync(x => x.IsActive == true);
            return new Response<UserCertificate>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}