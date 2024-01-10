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
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserLanguage>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
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

        public async Task<Response<UserLanguage>> UpdateAsync(UserLanguageUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserLanguage.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserLanguage>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserLanguage.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserLanguage>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserLanguage>> DeleteAsync(UserLanguageDeleteDto Model)
        {
            Collection = await UnitOfWork.UserLanguage.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserLanguage>(Collection[0]);

            await UnitOfWork.UserLanguage.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserLanguage>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserLanguage>> SelectAsync(UserLanguageSelectDto Model)
        {
            Collection = await UnitOfWork.UserLanguage.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserLanguage>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserLanguage>> SelectSingleAsync(UserLanguageSelectDto Model)
        {
            Collection = await UnitOfWork.UserLanguage.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
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