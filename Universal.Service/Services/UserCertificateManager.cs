namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<UserCertificateResponse>> InsertAsync(UserCertificateRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            List<Certificate> CertificateList = await UnitOfWork.Certificate.SelectAsync(x => x.Id == Model.CertificateId);

            Data = Mapper.Map<UserCertificate>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Certificate = CertificateList.FirstOrDefault(x => x.Id == Model.CertificateId) ?? new Certificate();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserCertificate>(Data);
            await UnitOfWork.UserCertificate.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserCertificateResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<UserCertificateResponse>> UpdateAsync(UserCertificateUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            List<Certificate> CertificateList = await UnitOfWork.Certificate.SelectAsync(x => x.Id == Model.CertificateId);
            Collection = await UnitOfWork.UserCertificate.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserCertificate>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Certificate = CertificateList.FirstOrDefault(x => x.Id == Model.CertificateId) ?? new Certificate();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserCertificate.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserCertificateResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserCertificateResponse>> DeleteAsync(UserCertificateDeleteDto Model)
        {
            Collection = await UnitOfWork.UserCertificate.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserCertificate>(Collection[0]);

            await UnitOfWork.UserCertificate.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserCertificateResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserCertificateResponse>> SelectAsync(UserCertificateSelectDto Model)
        {
            Collection = await UnitOfWork.UserCertificate.SelectAsync(x => x.IsActive == true, x => x.User, x => x.Certificate);
            return new Response<UserCertificateResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserCertificateResponse>> SelectSingleAsync(UserCertificateSelectDto Model)
        {
            Collection = await UnitOfWork.UserCertificate.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User, x => x.Certificate);
            return new Response<UserCertificateResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}