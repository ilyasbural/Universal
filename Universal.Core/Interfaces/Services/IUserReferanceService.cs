namespace Universal.Core
{
    public interface IUserReferanceService
    {
        Task<Response<UserReferance>> InsertAsync(UserReferanceRegisterDto Model);
        Task<Response<UserReferance>> UpdateAsync(UserReferanceUpdateDto Model);
        Task<Response<UserReferance>> DeleteAsync(UserReferanceDeleteDto Model);
        Task<Response<UserReferance>> SelectAsync(UserReferanceSelectDto Model);
        Task<Response<UserReferance>> SelectSingleAsync(UserReferanceSelectDto Model);
    }
}