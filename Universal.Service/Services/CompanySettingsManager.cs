namespace Universal.Service
{
    using Core;
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

        public async Task<Response<CompanySettings>> InsertAsync(CompanySettingsRegisterDto Model)
        {
            Data = Mapper.Map<CompanySettings>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<CompanySettings>(Data);
            await UnitOfWork.CompanySettings.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanySettings>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanySettings>> UpdateAsync(CompanySettingsUpdateDto Model)
        {
            Collection = await UnitOfWork.CompanySettings.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanySettings>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.CompanySettings.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanySettings>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanySettings>> DeleteAsync(CompanySettingsDeleteDto Model)
        {
            Collection = await UnitOfWork.CompanySettings.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanySettings>(Collection[0]);

            await UnitOfWork.CompanySettings.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanySettings>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanySettings>> SelectAsync(CompanySettingsSelectDto Model)
        {
            Collection = await UnitOfWork.CompanySettings.SelectAsync(x => x.IsActive == true);
            return new Response<CompanySettings>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanySettings>> SelectSingleAsync(CompanySettingsSelectDto Model)
        {
            Collection = await UnitOfWork.CompanySettings.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<CompanySettings>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}