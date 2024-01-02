namespace Universal.Core
{
    public interface ICountryService
    {
        Task<Response<Country>> InsertAsync(CountryRegisterDto Model);
        Task<Response<Country>> UpdateAsync(CountryUpdateDto Model);
        Task<Response<Country>> DeleteAsync(CountryDeleteDto Model);
        Task<Response<Country>> SelectAsync(CountrySelectDto Model);
        Task<Response<Country>> SelectSingleAsync(CountrySelectDto Model);
    }
}