namespace Universal.Core
{
    public interface INetworkCommentService
    {
        Task<Response<NetworkComment>> InsertAsync(NetworkCommentRegisterDto Model);
        Task<Response<NetworkComment>> SelectAsync();
    }
}