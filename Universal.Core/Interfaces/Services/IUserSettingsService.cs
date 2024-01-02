namespace Universal.Core
{
    public interface IUserSettingsService
    {
        Task<Response<UserSettings>> InsertAsync(UserSettingsRegisterDto Model);
        Task<Response<UserSettings>> UpdateAsync(UserSettingsUpdateDto Model);
        Task<Response<UserSettings>> DeleteAsync(UserSettingsDeleteDto Model);
        Task<Response<UserSettings>> SelectAsync(UserSettingsSelectDto Model);
        Task<Response<UserSettings>> SelectSingleAsync(UserSettingsSelectDto Model);
    }
}