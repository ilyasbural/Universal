namespace Universal.Core
{
    public interface IUserReferanceService
    {
        Task<Common.Response<Common.UserReferanceResponse>> InsertAsync(UserReferanceRegisterDto Model);
        Task<Common.Response<Common.UserReferanceResponse>> UpdateAsync(UserReferanceUpdateDto Model);
        Task<Common.Response<Common.UserReferanceResponse>> DeleteAsync(UserReferanceDeleteDto Model);
        Task<Common.Response<Common.UserReferanceResponse>> SelectAsync(UserReferanceSelectDto Model);
        Task<Common.Response<Common.UserReferanceResponse>> SelectSingleAsync(UserReferanceSelectDto Model);
    }
}