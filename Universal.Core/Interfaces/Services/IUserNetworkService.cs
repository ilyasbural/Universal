namespace Universal.Core
{
    public interface IUserNetworkService
    {
        Task<Response<UserNetwork>> InsertAsync(UserNetworkRegisterDto Model);
        Task<Response<UserNetwork>> SelectAsync();
    }
}