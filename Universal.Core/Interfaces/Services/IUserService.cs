namespace Universal.Core
{
    public interface IUserService
    {
        Task<Response<User>> InsertAsync(UserRegisterDto Model);
        Task<Response<User>> SelectAsync();
    }
}