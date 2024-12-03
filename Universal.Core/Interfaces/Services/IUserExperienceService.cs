namespace Universal.Core
{
    public interface IUserExperienceService
    {
        Task<Response<UserExperience>> InsertAsync(UserExperienceRegisterDto Model);
        Task<Response<UserExperience>> UpdateAsync(UserExperienceUpdateDto Model);
        Task<Response<UserExperience>> DeleteAsync(UserExperienceDeleteDto Model);
        Task<Response<UserExperience>> SelectAsync(UserExperienceSelectDto Model);
        Task<Response<UserExperience>> SelectSingleAsync(UserExperienceSelectDto Model);
    }
}