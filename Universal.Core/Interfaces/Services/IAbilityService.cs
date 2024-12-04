namespace Universal.Core
{
    public interface IAbilityService
    {
        Task<Common.Response<Common.AbilityResponse>> InsertAsync(AbilityRegisterDto Model);
        Task<Common.Response<Common.AbilityResponse>> UpdateAsync(AbilityUpdateDto Model);
        Task<Common.Response<Common.AbilityResponse>> DeleteAsync(AbilityDeleteDto Model);
        Task<Common.Response<Common.AbilityResponse>> SelectAsync(AbilitySelectDto Model);
        Task<Common.Response<Common.AbilityResponse>> SelectSingleAsync(AbilitySelectDto Model);
    }
}