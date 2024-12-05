namespace Universal.Core
{
    public interface IUserEducationService
    {
        Task<Common.Response<Common.UserEducationResponse>> InsertAsync(UserEducationRegisterDto Model);
        Task<Common.Response<Common.UserEducationResponse>> UpdateAsync(UserEducationUpdateDto Model);
        Task<Common.Response<Common.UserEducationResponse>> DeleteAsync(UserEducationDeleteDto Model);
        Task<Common.Response<Common.UserEducationResponse>> SelectAsync(UserEducationSelectDto Model);
        Task<Common.Response<Common.UserEducationResponse>> SelectSingleAsync(UserEducationSelectDto Model);
    }
}