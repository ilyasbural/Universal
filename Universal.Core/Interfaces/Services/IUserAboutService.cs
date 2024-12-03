namespace Universal.Core
{
    public interface IUserAboutService
    {
        Task<Response<UserAbout>> InsertAsync(UserAboutRegisterDto Model);
        Task<Response<UserAbout>> UpdateAsync(UserAboutUpdateDto Model);
        Task<Response<UserAbout>> DeleteAsync(UserAboutDeleteDto Model);
        Task<Response<UserAbout>> SelectAsync(UserAbilitySelectDto Model);
        Task<Response<UserAbout>> SelectSingleAsync(UserAbilitySelectDto Model);
    }
}