namespace Universal.Core
{
    public interface ILanguageService
    {
        Task<Response<Language>> InsertAsync(LanguageRegisterDto Model);
        Task<Response<Language>> SelectAsync();
    }
}