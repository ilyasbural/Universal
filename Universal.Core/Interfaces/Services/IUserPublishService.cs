namespace Universal.Core
{
    public interface IUserPublishService
    {
        Task<Response<UserPublish>> InsertAsync(UserPublishRegisterDto Model);
        Task<Response<UserPublish>> UpdateAsync(UserPublishUpdateDto Model);
        Task<Response<UserPublish>> DeleteAsync(UserPublishDeleteDto Model);
        Task<Response<UserPublish>> SelectAsync(UserPublishSelectDto Model);
        Task<Response<UserPublish>> SelectSingleAsync(UserPublishSelectDto Model);
    }
}