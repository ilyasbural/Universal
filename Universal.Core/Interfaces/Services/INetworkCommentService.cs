namespace Universal.Core
{
    public interface INetworkCommentService
    {
        Task<Response<NetworkComment>> InsertAsync(NetworkCommentRegisterDto Model);
        Task<Response<NetworkComment>> UpdateAsync(NetworkCommentUpdateDto Model);
        Task<Response<NetworkComment>> DeleteAsync(NetworkCommentDeleteDto Model);
        Task<Response<NetworkComment>> SelectAsync(NetworkCommentSelectDto Model);
        Task<Response<NetworkComment>> SelectSingleAsync(NetworkCommentSelectDto Model);
    }
}