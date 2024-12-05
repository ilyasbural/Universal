namespace Universal.Core
{
    public interface IUserCountryService
    {
        Task<Common.Response<Common.UserCountryResponse>> InsertAsync(UserCountryRegisterDto Model);
        Task<Common.Response<Common.UserCountryResponse>> UpdateAsync(UserCountryUpdateDto Model);
        Task<Common.Response<Common.UserCountryResponse>> DeleteAsync(UserCountryDeleteDto Model);
        Task<Common.Response<Common.UserCountryResponse>> SelectAsync(UserCountrySelectDto Model);
        Task<Common.Response<Common.UserCountryResponse>> SelectSingleAsync(UserCountrySelectDto Model);
    }
}