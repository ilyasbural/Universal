namespace Universal.Core
{
    public interface IUserService
    {
        Task<Common.Response<Common.UserResponse>> InsertAsync(UserRegisterDto Model);
        Task<Common.Response<Common.UserResponse>> UpdateAsync(UserUpdateDto Model);
        Task<Common.Response<Common.UserResponse>> DeleteAsync(UserDeleteDto Model);
        Task<Common.Response<Common.UserResponse>> SelectAsync(UserSelectDto Model);
        Task<Common.Response<Common.UserResponse>> SelectSingleAsync(UserSelectDto Model);
    }
}