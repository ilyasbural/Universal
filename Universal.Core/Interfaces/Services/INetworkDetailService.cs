namespace Universal.Core
{
    public interface INetworkDetailService
    {
        Task<Response<NetworkDetail>> InsertAsync(NetworkDetailRegisterDto Model);
        Task<Response<NetworkDetail>> SelectAsync();
    }
}