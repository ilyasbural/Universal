namespace Universal.Core
{
    public interface IUserFollowerService
    {
        Task<Common.Response<Common.UserFollowerResponse>> InsertAsync(UserFollowerRegisterDto Model);
        Task<Common.Response<Common.UserFollowerResponse>> UpdateAsync(UserFollowerUpdateDto Model);
        Task<Common.Response<Common.UserFollowerResponse>> DeleteAsync(UserFollowerDeleteDto Model);
        Task<Common.Response<Common.UserFollowerResponse>> SelectAsync(UserFollowerSelectDto Model);
        Task<Common.Response<Common.UserFollowerResponse>> SelectSingleAsync(UserFollowerSelectDto Model);
    }
}