namespace Universal.Core
{
    public interface INetworkDetailService
    {
        Task<Common.Response<Common.NetworkDetailResponse>> InsertAsync(NetworkDetailRegisterDto Model);
        Task<Common.Response<Common.NetworkDetailResponse>> UpdateAsync(NetworkDetailUpdateDto Model);
        Task<Common.Response<Common.NetworkDetailResponse>> DeleteAsync(NetworkDetailDeleteDto Model);
        Task<Common.Response<Common.NetworkDetailResponse>> SelectAsync(NetworkDetailSelectDto Model);
        Task<Common.Response<Common.NetworkDetailResponse>> SelectSingleAsync(NetworkDetailSelectDto Model);
    }
}