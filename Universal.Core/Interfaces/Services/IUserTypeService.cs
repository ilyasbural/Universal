namespace Universal.Core
{
    public interface IUserTypeService
    {
        Task<Response<UserType>> InsertAsync(UserTypeRegisterDto Model);
        Task<Response<UserType>> SelectAsync();
    }
}