namespace Universal.Core
{
    public interface IUserPublishService
    {
        Task<Common.Response<Common.UserPublishResponse>> InsertAsync(UserPublishRegisterDto Model);
        Task<Common.Response<Common.UserPublishResponse>> UpdateAsync(UserPublishUpdateDto Model);
        Task<Common.Response<Common.UserPublishResponse>> DeleteAsync(UserPublishDeleteDto Model);
        Task<Common.Response<Common.UserPublishResponse>> SelectAsync(UserPublishSelectDto Model);
        Task<Common.Response<Common.UserPublishResponse>> SelectSingleAsync(UserPublishSelectDto Model);
    }
}