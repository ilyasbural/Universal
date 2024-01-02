namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class ManagementEmailManager : BusinessObject<ManagementEmail>, IManagementEmailService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<ManagementEmail> Validator;

        public ManagementEmailManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<ManagementEmail> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<ManagementEmail>> DeleteAsync(ManagementEmailDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ManagementEmail>> InsertAsync(ManagementEmailRegisterDto Model)
        {
            Data = Mapper.Map<ManagementEmail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<ManagementEmail>(Data);
            await UnitOfWork.ManagementEmail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementEmail>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementEmail>> SelectAsync()
        {
            Collection = await UnitOfWork.ManagementEmail.SelectAsync(x => x.IsActive == true);
            return new Response<ManagementEmail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<ManagementEmail>> SelectAsync(ManagementEmailSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ManagementEmail>> SelectSingleAsync(ManagementEmailSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ManagementEmail>> UpdateAsync(ManagementEmailUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}