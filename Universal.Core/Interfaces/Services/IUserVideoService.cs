namespace Universal.Core
{
    public interface IUserVideoService
    {
        Task<Response<UserVideo>> InsertAsync(UserVideoRegisterDto Model);
        Task<Response<UserVideo>> SelectAsync();
    }
}