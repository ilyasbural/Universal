namespace Universal.Core
{
    public interface IUserFollowerService
    {
        Task<Response<UserFollower>> InsertAsync(UserFollowerRegisterDto Model);
        Task<Response<UserFollower>> UpdateAsync(UserFollowerUpdateDto Model);
        Task<Response<UserFollower>> DeleteAsync(UserFollowerDeleteDto Model);
        Task<Response<UserFollower>> SelectAsync(UserFollowerSelectDto Model);
        Task<Response<UserFollower>> SelectSingleAsync(UserFollowerSelectDto Model);
    }
}