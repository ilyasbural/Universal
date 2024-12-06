namespace Universal.Service
{
    using Core;
	using Common;
	using AutoMapper;
    using FluentValidation;

    public class CompanySettingsManager : BusinessObject<CompanySettings>, ICompanySettingsService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<CompanySettings> Validator;

        public CompanySettingsManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<CompanySettings> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<CompanySettingsResponse>> InsertAsync(CompanySettingsRegisterDto Model)
        {
            Data = Mapper.Map<CompanySettings>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<CompanySettings>(Data);
            await UnitOfWork.CompanySettings.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanySettingsResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<CompanySettingsResponse>> UpdateAsync(CompanySettingsUpdateDto Model)
        {
            Collection = await UnitOfWork.CompanySettings.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanySettings>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.CompanySettings.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanySettingsResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanySettingsResponse>> DeleteAsync(CompanySettingsDeleteDto Model)
        {
            Collection = await UnitOfWork.CompanySettings.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanySettings>(Collection[0]);

            await UnitOfWork.CompanySettings.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanySettingsResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanySettingsResponse>> SelectAsync(CompanySettingsSelectDto Model)
        {
            Collection = await UnitOfWork.CompanySettings.SelectAsync(x => x.IsActive == true);
            return new Response<CompanySettingsResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanySettingsResponse>> SelectSingleAsync(CompanySettingsSelectDto Model)
        {
            Collection = await UnitOfWork.CompanySettings.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<CompanySettingsResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}