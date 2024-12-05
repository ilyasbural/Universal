namespace Universal.Core
{
    public interface IUserProjectService
    {
        Task<Common.Response<Common.UserProjectResponse>> InsertAsync(UserProjectRegisterDto Model);
        Task<Common.Response<Common.UserProjectResponse>> UpdateAsync(UserProjectUpdateDto Model);
        Task<Common.Response<Common.UserProjectResponse>> DeleteAsync(UserProjectDeleteDto Model);
        Task<Common.Response<Common.UserProjectResponse>> SelectAsync(UserProjectSelectDto Model);
        Task<Common.Response<Common.UserProjectResponse>> SelectSingleAsync(UserProjectSelectDto Model);
    }
}