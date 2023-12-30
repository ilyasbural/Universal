namespace Universal.Core
{
    public interface INetworkActionService
    {
        Task<Response<NetworkAction>> InsertAsync(NetworkActionRegisterDto Model);
        Task<Response<NetworkAction>> SelectAsync();
    }
}