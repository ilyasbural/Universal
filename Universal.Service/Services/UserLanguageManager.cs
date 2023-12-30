namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserLanguageManager : BusinessObject<UserLanguage>, IUserLanguageService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserLanguage> Validator;

        public UserLanguageManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserLanguage> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserLanguage>> InsertAsync(UserLanguageRegisterDto Model)
        {
            Data = Mapper.Map<UserLanguage>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserLanguage>(Data);
            await UnitOfWork.UserLanguage.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserLanguage>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserLanguage>> SelectAsync()
        {
            Collection = await UnitOfWork.UserLanguage.SelectAsync(x => x.IsActive == true);
            return new Response<UserLanguage>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}