namespace Universal.Core
{
    public interface IUserLanguageService
    {
        Task<Common.Response<Common.UserLanguageResponse>> InsertAsync(UserLanguageRegisterDto Model);
        Task<Common.Response<Common.UserLanguageResponse>> UpdateAsync(UserLanguageUpdateDto Model);
        Task<Common.Response<Common.UserLanguageResponse>> DeleteAsync(UserLanguageDeleteDto Model);
        Task<Common.Response<Common.UserLanguageResponse>> SelectAsync(UserLanguageSelectDto Model);
        Task<Common.Response<Common.UserLanguageResponse>> SelectSingleAsync(UserLanguageSelectDto Model);
    }
}