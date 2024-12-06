namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<ManagementEmailResponse>> InsertAsync(ManagementEmailRegisterDto Model)
        {
            Data = Mapper.Map<ManagementEmail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<ManagementEmail>(Data);
            await UnitOfWork.ManagementEmail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementEmailResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementEmailResponse>> UpdateAsync(ManagementEmailUpdateDto Model)
        {
            Collection = await UnitOfWork.ManagementEmail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<ManagementEmail>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.ManagementEmail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementEmailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementEmailResponse>> DeleteAsync(ManagementEmailDeleteDto Model)
        {
            Collection = await UnitOfWork.ManagementEmail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<ManagementEmail>(Collection[0]);

            await UnitOfWork.ManagementEmail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementEmailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementEmailResponse>> SelectAsync(ManagementEmailSelectDto Model)
        {
            Collection = await UnitOfWork.ManagementEmail.SelectAsync(x => x.IsActive == true);
            return new Response<ManagementEmailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementEmailResponse>> SelectSingleAsync(ManagementEmailSelectDto Model)
        {
            Collection = await UnitOfWork.ManagementEmail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<ManagementEmailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}