namespace Universal.Core
{
    public interface IUserSettingsService
    {
        Task<Response<UserSettings>> InsertAsync(UserSettingsRegisterDto Model);
        Task<Response<UserSettings>> SelectAsync();
    }
}