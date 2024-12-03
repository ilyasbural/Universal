namespace Universal.Core
{
    public interface INetworkActionService
    {
        Task<Response<NetworkAction>> InsertAsync(NetworkActionRegisterDto Model);
        Task<Response<NetworkAction>> UpdateAsync(NetworkActionUpdateDto Model);
        Task<Response<NetworkAction>> DeleteAsync(NetworkActionDeleteDto Model);
        Task<Response<NetworkAction>> SelectAsync(NetworkActionSelectDto Model);
        Task<Response<NetworkAction>> SelectSingleAsync(NetworkActionSelectDto Model);
    }
}