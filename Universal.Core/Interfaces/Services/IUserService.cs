namespace Universal.Core
{
    public interface IUserService
    {
        Task<Response<User>> InsertAsync(UserRegisterDto Model);
        Task<Response<User>> UpdateAsync(UserUpdateDto Model);
        Task<Response<User>> DeleteAsync(UserDeleteDto Model);
        Task<Response<User>> SelectAsync(UserSelectDto Model);
        Task<Response<User>> SelectSingleAsync(UserSelectDto Model);
    }
}