namespace Universal.Core
{
    public interface INetworkCommentService
    {
        Task<Common.Response<Common.NetworkCommentResponse>> InsertAsync(NetworkCommentRegisterDto Model);
        Task<Common.Response<Common.NetworkCommentResponse>> UpdateAsync(NetworkCommentUpdateDto Model);
        Task<Common.Response<Common.NetworkCommentResponse>> DeleteAsync(NetworkCommentDeleteDto Model);
        Task<Common.Response<Common.NetworkCommentResponse>> SelectAsync(NetworkCommentSelectDto Model);
        Task<Common.Response<Common.NetworkCommentResponse>> SelectSingleAsync(NetworkCommentSelectDto Model);
    }
}