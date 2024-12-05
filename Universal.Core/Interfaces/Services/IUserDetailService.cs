namespace Universal.Core
{
    public interface IUserDetailService
    {
        Task<Common.Response<Common.UserDetailResponse>> InsertAsync(UserDetailRegisterDto Model);
        Task<Common.Response<Common.UserDetailResponse>> UpdateAsync(UserDetailUpdateDto Model);
        Task<Common.Response<Common.UserDetailResponse>> DeleteAsync(UserDetailDeleteDto Model);
        Task<Common.Response<Common.UserDetailResponse>> SelectAsync(UserDetailSelectDto Model);
        Task<Common.Response<Common.UserDetailResponse>> SelectSingleAsync(UserDetailSelectDto Model);
    }
}