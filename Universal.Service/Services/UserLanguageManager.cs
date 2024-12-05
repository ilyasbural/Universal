namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<UserLanguageResponse>> InsertAsync(UserLanguageRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            List<Language> LanguageList = await UnitOfWork.Language.SelectAsync(x => x.Id == Model.LanguageId);

            Data = Mapper.Map<UserLanguage>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Language = LanguageList.FirstOrDefault(x => x.Id == Model.LanguageId) ?? new Language();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserLanguage>(Data);
            await UnitOfWork.UserLanguage.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserLanguageResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<UserLanguageResponse>> UpdateAsync(UserLanguageUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            List<Language> LanguageList = await UnitOfWork.Language.SelectAsync(x => x.Id == Model.LanguageId);
            Collection = await UnitOfWork.UserLanguage.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserLanguage>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Language = LanguageList.FirstOrDefault(x => x.Id == Model.LanguageId) ?? new Language();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserLanguage.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserLanguageResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserLanguageResponse>> DeleteAsync(UserLanguageDeleteDto Model)
        {
            Collection = await UnitOfWork.UserLanguage.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserLanguage>(Collection[0]);

            await UnitOfWork.UserLanguage.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserLanguageResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserLanguageResponse>> SelectAsync(UserLanguageSelectDto Model)
        {
            Collection = await UnitOfWork.UserLanguage.SelectAsync(x => x.IsActive == true, x => x.User, x => x.Language);
            return new Response<UserLanguageResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserLanguageResponse>> SelectSingleAsync(UserLanguageSelectDto Model)
        {
            Collection = await UnitOfWork.UserLanguage.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User, x => x.Language);
            return new Response<UserLanguageResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}