namespace Universal.Core
{
    public interface IUserAboutService
    {
        Task<Common.Response<Common.UserAboutResponse>> InsertAsync(UserAboutRegisterDto Model);
        Task<Common.Response<Common.UserAboutResponse>> UpdateAsync(UserAboutUpdateDto Model);
        Task<Common.Response<Common.UserAboutResponse>> DeleteAsync(UserAboutDeleteDto Model);
        Task<Common.Response<Common.UserAboutResponse>> SelectAsync(UserAbilitySelectDto Model);
        Task<Common.Response<Common.UserAboutResponse>> SelectSingleAsync(UserAbilitySelectDto Model);
    }
}