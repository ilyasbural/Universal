namespace Universal.Core
{
    public interface IUserAbilityService
    {
        Task<Response<UserAbility>> InsertAsync(UserAbilityRegisterDto Model);
        Task<Response<UserAbility>> SelectAsync();
    }
}