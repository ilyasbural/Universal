namespace Universal.Core
{
    public interface ICountryService
    {
        Task<Response<Country>> InsertAsync(CountryRegisterDto Model);
        Task<Response<Country>> SelectAsync();
    }
}