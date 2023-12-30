namespace Universal.Core
{
    public interface IUserPublishService
    {
        Task<Response<UserPublish>> InsertAsync(UserPublishRegisterDto Model);
        Task<Response<UserPublish>> SelectAsync();
    }
}