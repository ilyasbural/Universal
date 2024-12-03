namespace Universal.Core
{
    public interface IUserDetailService
    {
        Task<Response<UserDetail>> InsertAsync(UserDetailRegisterDto Model);
        Task<Response<UserDetail>> UpdateAsync(UserDetailUpdateDto Model);
        Task<Response<UserDetail>> DeleteAsync(UserDetailDeleteDto Model);
        Task<Response<UserDetail>> SelectAsync(UserDetailSelectDto Model);
        Task<Response<UserDetail>> SelectSingleAsync(UserDetailSelectDto Model);
    }
}