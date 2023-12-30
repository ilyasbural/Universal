namespace Universal.Core
{
    public interface IUserFollowerService
    {
        Task<Response<UserFollower>> InsertAsync(UserFollowerRegisterDto Model);
        Task<Response<UserFollower>> SelectAsync();
    }
}