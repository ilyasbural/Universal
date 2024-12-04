namespace Universal.Core
{
    public interface ILanguageService
    {
        Task<Common.Response<Common.LanguageResponse>> InsertAsync(LanguageRegisterDto Model);
        Task<Common.Response<Common.LanguageResponse>> UpdateAsync(LanguageUpdateDto Model);
        Task<Common.Response<Common.LanguageResponse>> DeleteAsync(LanguageDeleteDto Model);
        Task<Common.Response<Common.LanguageResponse>> SelectAsync(LanguageSelectDto Model);
        Task<Common.Response<Common.LanguageResponse>> SelectSingleAsync(LanguageSelectDto Model);
    }
}