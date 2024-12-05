namespace Universal.Core
{
    public interface IUserVideoService
    {
        Task<Common.Response<Common.UserVideoResponse>> InsertAsync(UserVideoRegisterDto Model);
        Task<Common.Response<Common.UserVideoResponse>> UpdateAsync(UserVideoUpdateDto Model);
        Task<Common.Response<Common.UserVideoResponse>> DeleteAsync(UserVideoDeleteDto Model);
        Task<Common.Response<Common.UserVideoResponse>> SelectAsync(UserVideoSelectDto Model);
        Task<Common.Response<Common.UserVideoResponse>> SelectSingleAsync(UserVideoSelectDto Model);
    }
}