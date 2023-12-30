namespace Universal.Core
{
    public interface IUserAboutService
    {
        Task<Response<UserAbout>> InsertAsync(UserAboutRegisterDto Model);
        Task<Response<UserAbout>> SelectAsync();
    }
}