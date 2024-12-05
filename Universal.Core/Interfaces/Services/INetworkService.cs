namespace Universal.Core
{
    public interface INetworkService
    {
        Task<Common.Response<Common.NetworkResponse>> InsertAsync(NetworkRegisterDto Model);
        Task<Common.Response<Common.NetworkResponse>> UpdateAsync(NetworkUpdateDto Model);
        Task<Common.Response<Common.NetworkResponse>> DeleteAsync(NetworkDeleteDto Model);
        Task<Common.Response<Common.NetworkResponse>> SelectAsync(NetworkSelectDto Model);
        Task<Common.Response<Common.NetworkResponse>> SelectSingleAsync(NetworkSelectDto Model);
    }
}