namespace Universal.Core
{
    public interface IUserExperienceService
    {
        Task<Common.Response<Common.UserExperienceResponse>> InsertAsync(UserExperienceRegisterDto Model);
        Task<Common.Response<Common.UserExperienceResponse>> UpdateAsync(UserExperienceUpdateDto Model);
        Task<Common.Response<Common.UserExperienceResponse>> DeleteAsync(UserExperienceDeleteDto Model);
        Task<Common.Response<Common.UserExperienceResponse>> SelectAsync(UserExperienceSelectDto Model);
        Task<Common.Response<Common.UserExperienceResponse>> SelectSingleAsync(UserExperienceSelectDto Model);
    }
}