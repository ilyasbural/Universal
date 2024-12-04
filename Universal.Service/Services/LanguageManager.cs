namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class LanguageManager : BusinessObject<Language>, ILanguageService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Language> Validator;

        public LanguageManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Language> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<LanguageResponse>> InsertAsync(LanguageRegisterDto Model)
        {
            Data = Mapper.Map<Language>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Language>(Data);
            await UnitOfWork.Language.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<LanguageResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<LanguageResponse>> UpdateAsync(LanguageUpdateDto Model)
        {
            Collection = await UnitOfWork.Language.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Language>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Language.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<LanguageResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<LanguageResponse>> DeleteAsync(LanguageDeleteDto Model)
        {
            Collection = await UnitOfWork.Language.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Language>(Collection[0]);

            await UnitOfWork.Language.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<LanguageResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<LanguageResponse>> SelectAsync(LanguageSelectDto Model)
        {
            Collection = await UnitOfWork.Language.SelectAsync(x => x.IsActive == true);
            return new Response<LanguageResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<LanguageResponse>> SelectSingleAsync(LanguageSelectDto Model)
        {
            Collection = await UnitOfWork.Language.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<LanguageResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}