namespace Universal.Core
{
    public interface IUserLanguageService
    {
        Task<Response<UserLanguage>> InsertAsync(UserLanguageRegisterDto Model);
        Task<Response<UserLanguage>> SelectAsync();
    }
}