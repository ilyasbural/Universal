namespace Universal.Core
{
    public interface IUserTypeService
    {
        Task<Response<UserType>> InsertAsync(UserTypeRegisterDto Model);
        Task<Response<UserType>> UpdateAsync(UserTypeUpdateDto Model);
        Task<Response<UserType>> DeleteAsync(UserTypeDeleteDto Model);
        Task<Response<UserType>> SelectAsync(UserTypeSelectDto Model);
        Task<Response<UserType>> SelectSingleAsync(UserTypeSelectDto Model);
    }
}