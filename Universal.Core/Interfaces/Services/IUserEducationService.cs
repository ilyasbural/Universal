namespace Universal.Core
{
    public interface IUserEducationService
    {
        Task<Response<UserEducation>> InsertAsync(UserEducationRegisterDto Model);
        Task<Response<UserEducation>> SelectAsync();
    }
}