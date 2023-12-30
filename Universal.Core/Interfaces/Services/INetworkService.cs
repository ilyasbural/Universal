namespace Universal.Core
{
    public interface INetworkService
    {
        Task<Response<Network>> InsertAsync(NetworkRegisterDto Model);
        Task<Response<Network>> SelectAsync();
    }
}