namespace Universal.Core
{
    public interface IAbilityService
    {
        Task<Response<Ability>> InsertAsync(AbilityRegisterDto Model);
        Task<Response<Ability>> UpdateAsync(AbilityUpdateDto Model);
        Task<Response<Ability>> DeleteAsync(AbilityDeleteDto Model);
        Task<Response<Ability>> SelectAsync(AbilitySelectDto Model);
        Task<Response<Ability>> SelectSingleAsync(AbilitySelectDto Model);
    }
}