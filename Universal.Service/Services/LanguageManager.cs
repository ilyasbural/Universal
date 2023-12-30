namespace Universal.Service
{
    using Core;
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

        public async Task<Response<Language>> InsertAsync(LanguageRegisterDto Model)
        {
            Data = Mapper.Map<Language>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Language>(Data);
            await UnitOfWork.Language.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Language>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Language>> SelectAsync()
        {
            Collection = await UnitOfWork.Language.SelectAsync(x => x.IsActive == true);
            return new Response<Language>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}