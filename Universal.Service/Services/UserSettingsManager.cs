namespace Universal.Service
{
    using Core;
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

        public Task<Response<UserSettings>> DeleteAsync(UserSettingsDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserSettings>> InsertAsync(UserSettingsRegisterDto Model)
        {
            Data = Mapper.Map<UserSettings>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserSettings>(Data);
            await UnitOfWork.UserSettings.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserSettings>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserSettings>> SelectAsync()
        {
            Collection = await UnitOfWork.UserSettings.SelectAsync(x => x.IsActive == true);
            return new Response<UserSettings>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<UserSettings>> SelectAsync(UserSettingsSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserSettings>> SelectSingleAsync(UserSettingsSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserSettings>> UpdateAsync(UserSettingsUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}