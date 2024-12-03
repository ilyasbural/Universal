namespace Universal.Core
{
    public interface ILanguageService
    {
        Task<Response<Language>> InsertAsync(LanguageRegisterDto Model);
        Task<Response<Language>> UpdateAsync(LanguageUpdateDto Model);
        Task<Response<Language>> DeleteAsync(LanguageDeleteDto Model);
        Task<Response<Language>> SelectAsync(LanguageSelectDto Model);
        Task<Response<Language>> SelectSingleAsync(LanguageSelectDto Model);
    }
}