namespace Universal.Core
{
    public interface IUserEducationService
    {
        Task<Response<UserEducation>> InsertAsync(UserEducationRegisterDto Model);
        Task<Response<UserEducation>> UpdateAsync(UserEducationUpdateDto Model);
        Task<Response<UserEducation>> DeleteAsync(UserEducationDeleteDto Model);
        Task<Response<UserEducation>> SelectAsync(UserEducationSelectDto Model);
        Task<Response<UserEducation>> SelectSingleAsync(UserEducationSelectDto Model);
    }
}