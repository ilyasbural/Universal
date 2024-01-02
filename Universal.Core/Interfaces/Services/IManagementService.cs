namespace Universal.Core
{
    public interface IManagementService
    {
        Task<Response<Management>> InsertAsync(ManagementRegisterDto Model);
        Task<Response<Management>> UpdateAsync(ManagementUpdateDto Model);
        Task<Response<Management>> DeleteAsync(ManagementDeleteDto Model);
        Task<Response<Management>> SelectAsync(ManagementSelectDto Model);
        Task<Response<Management>> SelectSingleAsync(ManagementSelectDto Model);
    }
}