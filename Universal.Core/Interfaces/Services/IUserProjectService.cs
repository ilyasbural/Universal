namespace Universal.Core
{
    public interface IUserProjectService
    {
        Task<Response<UserProject>> InsertAsync(UserProjectRegisterDto Model);
        Task<Response<UserProject>> SelectAsync();
    }
}