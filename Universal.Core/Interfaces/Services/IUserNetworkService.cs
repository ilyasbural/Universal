namespace Universal.Core
{
    public interface IUserNetworkService
    {
        Task<Response<UserNetwork>> InsertAsync(UserNetworkRegisterDto Model);
        Task<Response<UserNetwork>> UpdateAsync(UserNetworkUpdateDto Model);
        Task<Response<UserNetwork>> DeleteAsync(UserNetworkDeleteDto Model);
        Task<Response<UserNetwork>> SelectAsync(UserNetworkSelectDto Model);
        Task<Response<UserNetwork>> SelectSingleAsync(UserNetworkSelectDto Model);
    }
}