namespace Universal.Core
{
    public interface IUserAbilityService
    {
        Task<Common.Response<Common.UserAbilityResponse>> InsertAsync(UserAbilityRegisterDto Model);
        Task<Common.Response<Common.UserAbilityResponse>> UpdateAsync(UserAbilityUpdateDto Model);
        Task<Common.Response<Common.UserAbilityResponse>> DeleteAsync(UserAbilityDeleteDto Model);
        Task<Common.Response<Common.UserAbilityResponse>> SelectAsync(UserAbilitySelectDto Model);
        Task<Common.Response<Common.UserAbilityResponse>> SelectSingleAsync(UserAbilitySelectDto Model);
    }
}