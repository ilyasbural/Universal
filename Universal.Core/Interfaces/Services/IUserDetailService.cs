namespace Universal.Core
{
    public interface IUserDetailService
    {
        Task<Response<UserDetail>> InsertAsync(UserDetailRegisterDto Model);
        Task<Response<UserDetail>> SelectAsync();
    }
}