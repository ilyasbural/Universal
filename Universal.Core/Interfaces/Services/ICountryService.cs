namespace Universal.Core
{
    public interface ICountryService
    {
        Task<Common.Response<Common.CountryResponse>> InsertAsync(CountryRegisterDto Model);
        Task<Common.Response<Common.CountryResponse>> UpdateAsync(CountryUpdateDto Model);
        Task<Common.Response<Common.CountryResponse>> DeleteAsync(CountryDeleteDto Model);
        Task<Common.Response<Common.CountryResponse>> SelectAsync(CountrySelectDto Model);
        Task<Common.Response<Common.CountryResponse>> SelectSingleAsync(CountrySelectDto Model);
    }
}