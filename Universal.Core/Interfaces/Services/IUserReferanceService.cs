namespace Universal.Core
{
    public interface IUserReferanceService
    {
        Task<Response<UserReferance>> InsertAsync(UserReferanceRegisterDto Model);
        Task<Response<UserReferance>> SelectAsync();
    }
}