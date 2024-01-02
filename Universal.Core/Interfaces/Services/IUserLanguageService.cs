namespace Universal.Core
{
    public interface IUserLanguageService
    {
        Task<Response<UserLanguage>> InsertAsync(UserLanguageRegisterDto Model);
        Task<Response<UserLanguage>> UpdateAsync(UserLanguageUpdateDto Model);
        Task<Response<UserLanguage>> DeleteAsync(UserLanguageDeleteDto Model);
        Task<Response<UserLanguage>> SelectAsync(UserLanguageSelectDto Model);
        Task<Response<UserLanguage>> SelectSingleAsync(UserLanguageSelectDto Model);
    }
}