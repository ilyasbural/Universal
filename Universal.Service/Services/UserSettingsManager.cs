namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class UserSettingsManager : BusinessObject<UserSettings>, IUserSettingsService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserSettings> Validator;

        public UserSettingsManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserSettings> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserSettingsResponse>> InsertAsync(UserSettingsRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserSettings>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserSettings>(Data);
            await UnitOfWork.UserSettings.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserSettingsResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<UserSettingsResponse>> UpdateAsync(UserSettingsUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserSettings.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserSettings>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserSettings.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserSettingsResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserSettingsResponse>> DeleteAsync(UserSettingsDeleteDto Model)
        {
            Collection = await UnitOfWork.UserSettings.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserSettings>(Collection[0]);

            await UnitOfWork.UserSettings.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserSettingsResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserSettingsResponse>> SelectAsync(UserSettingsSelectDto Model)
        {
            Collection = await UnitOfWork.UserSettings.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserSettingsResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserSettingsResponse>> SelectSingleAsync(UserSettingsSelectDto Model)
        {
            Collection = await UnitOfWork.UserSettings.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserSettingsResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}