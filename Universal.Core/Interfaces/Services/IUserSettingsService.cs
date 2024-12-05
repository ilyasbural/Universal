namespace Universal.Core
{
    public interface IUserSettingsService
    {
        Task<Common.Response<Common.UserSettingsResponse>> InsertAsync(UserSettingsRegisterDto Model);
        Task<Common.Response<Common.UserSettingsResponse>> UpdateAsync(UserSettingsUpdateDto Model);
        Task<Common.Response<Common.UserSettingsResponse>> DeleteAsync(UserSettingsDeleteDto Model);
        Task<Common.Response<Common.UserSettingsResponse>> SelectAsync(UserSettingsSelectDto Model);
        Task<Common.Response<Common.UserSettingsResponse>> SelectSingleAsync(UserSettingsSelectDto Model);
    }
}