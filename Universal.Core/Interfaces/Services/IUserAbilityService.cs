namespace Universal.Core
{
    public interface IUserAbilityService
    {
        Task<Response<UserAbility>> InsertAsync(UserAbilityRegisterDto Model);
        Task<Response<UserAbility>> UpdateAsync(UserAbilityUpdateDto Model);
        Task<Response<UserAbility>> DeleteAsync(UserAbilityDeleteDto Model);
        Task<Response<UserAbility>> SelectAsync(UserAbilitySelectDto Model);
        Task<Response<UserAbility>> SelectSingleAsync(UserAbilitySelectDto Model);
    }
}