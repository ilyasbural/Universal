namespace Universal.Core
{
    public interface IUserTypeService
    {
        Task<Common.Response<Common.UserTypeResponse>> InsertAsync(UserTypeRegisterDto Model);
        Task<Common.Response<Common.UserTypeResponse>> UpdateAsync(UserTypeUpdateDto Model);
        Task<Common.Response<Common.UserTypeResponse>> DeleteAsync(UserTypeDeleteDto Model);
        Task<Common.Response<Common.UserTypeResponse>> SelectAsync(UserTypeSelectDto Model);
        Task<Common.Response<Common.UserTypeResponse>> SelectSingleAsync(UserTypeSelectDto Model);
    }
}