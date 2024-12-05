namespace Universal.Core
{
    public interface INetworkActionService
    {
        Task<Common.Response<Common.NetworkActionResponse>> InsertAsync(NetworkActionRegisterDto Model);
        Task<Common.Response<Common.NetworkActionResponse>> UpdateAsync(NetworkActionUpdateDto Model);
        Task<Common.Response<Common.NetworkActionResponse>> DeleteAsync(NetworkActionDeleteDto Model);
        Task<Common.Response<Common.NetworkActionResponse>> SelectAsync(NetworkActionSelectDto Model);
        Task<Common.Response<Common.NetworkActionResponse>> SelectSingleAsync(NetworkActionSelectDto Model);
    }
}