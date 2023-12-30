namespace Universal.Core
{
    public interface IUserCountryService
    {
        Task<Response<UserCountry>> InsertAsync(UserCountryRegisterDto Model);
        Task<Response<UserCountry>> SelectAsync();
    }
}