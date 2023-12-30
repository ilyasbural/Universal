namespace Universal.Core
{
    public interface IAbilityService
    {
        Task<Response<Ability>> InsertAsync(AbilityRegisterDto Model);
        Task<Response<Ability>> SelectAsync();
    }
}