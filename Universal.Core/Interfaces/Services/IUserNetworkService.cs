namespace Universal.Core
{
    public interface IUserNetworkService
    {
        Task<Common.Response<Common.UserNetworkResponse>> InsertAsync(UserNetworkRegisterDto Model);
        Task<Common.Response<Common.UserNetworkResponse>> UpdateAsync(UserNetworkUpdateDto Model);
        Task<Common.Response<Common.UserNetworkResponse>> DeleteAsync(UserNetworkDeleteDto Model);
        Task<Common.Response<Common.UserNetworkResponse>> SelectAsync(UserNetworkSelectDto Model);
        Task<Common.Response<Common.UserNetworkResponse>> SelectSingleAsync(UserNetworkSelectDto Model);
    }
}