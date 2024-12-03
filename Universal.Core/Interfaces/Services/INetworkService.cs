namespace Universal.Core
{
    public interface INetworkService
    {
        Task<Response<Network>> InsertAsync(NetworkRegisterDto Model);
        Task<Response<Network>> UpdateAsync(NetworkUpdateDto Model);
        Task<Response<Network>> DeleteAsync(NetworkDeleteDto Model);
        Task<Response<Network>> SelectAsync(NetworkSelectDto Model);
        Task<Response<Network>> SelectSingleAsync(NetworkSelectDto Model);
    }
}