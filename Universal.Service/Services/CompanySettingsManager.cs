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

        public Task<Response<CompanySettings>> UpdateAsync(CompanySettingsUpdateDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CompanySettings>> DeleteAsync(CompanySettingsDeleteDto Model)
        {
            throw new NotImplementedException();
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

        public Task<Response<CompanySettings>> SelectSingleAsync(CompanySettingsSelectDto Model)
        {
            throw new NotImplementedException();
        }
    }
}