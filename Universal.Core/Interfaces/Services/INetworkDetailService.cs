namespace Universal.Core
{
    public interface INetworkDetailService
    {
        Task<Response<NetworkDetail>> InsertAsync(NetworkDetailRegisterDto Model);
        Task<Response<NetworkDetail>> UpdateAsync(NetworkDetailUpdateDto Model);
        Task<Response<NetworkDetail>> DeleteAsync(NetworkDetailDeleteDto Model);
        Task<Response<NetworkDetail>> SelectAsync(NetworkDetailSelectDto Model);
        Task<Response<NetworkDetail>> SelectSingleAsync(NetworkDetailSelectDto Model);
    }
}