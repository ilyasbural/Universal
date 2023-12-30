namespace Universal.Core
{
    public interface IUserExperienceService
    {
        Task<Response<UserExperience>> InsertAsync(UserExperienceRegisterDto Model);
        Task<Response<UserExperience>> SelectAsync();
    }
}