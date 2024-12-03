namespace Universal.Core
{
    public interface IUserVideoService
    {
        Task<Response<UserVideo>> InsertAsync(UserVideoRegisterDto Model);
        Task<Response<UserVideo>> UpdateAsync(UserVideoUpdateDto Model);
        Task<Response<UserVideo>> DeleteAsync(UserVideoDeleteDto Model);
        Task<Response<UserVideo>> SelectAsync(UserVideoSelectDto Model);
        Task<Response<UserVideo>> SelectSingleAsync(UserVideoSelectDto Model);
    }
}