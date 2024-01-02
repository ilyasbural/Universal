namespace Universal.Core
{
    public interface IUserProjectService
    {
        Task<Response<UserProject>> InsertAsync(UserProjectRegisterDto Model);
        Task<Response<UserProject>> UpdateAsync(UserProjectUpdateDto Model);
        Task<Response<UserProject>> DeleteAsync(UserProjectDeleteDto Model);
        Task<Response<UserProject>> SelectAsync(UserProjectSelectDto Model);
        Task<Response<UserProject>> SelectSingleAsync(UserProjectSelectDto Model);
    }
}