namespace Universal.Core
{
    public interface IUserCountryService
    {
        Task<Response<UserCountry>> InsertAsync(UserCountryRegisterDto Model);
        Task<Response<UserCountry>> UpdateAsync(UserCountryUpdateDto Model);
        Task<Response<UserCountry>> DeleteAsync(UserCountryDeleteDto Model);
        Task<Response<UserCountry>> SelectAsync(UserCountrySelectDto Model);
        Task<Response<UserCountry>> SelectSingleAsync(UserCountrySelectDto Model);
    }
}