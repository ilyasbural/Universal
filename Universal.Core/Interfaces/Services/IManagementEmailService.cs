namespace Universal.Core
{
    public interface IManagementEmailService
    {
        Task<Response<ManagementEmail>> InsertAsync(ManagementEmailRegisterDto Model);
        Task<Response<ManagementEmail>> UpdateAsync(ManagementEmailUpdateDto Model);
        Task<Response<ManagementEmail>> DeleteAsync(ManagementEmailDeleteDto Model);
        Task<Response<ManagementEmail>> SelectAsync(ManagementEmailSelectDto Model);
        Task<Response<ManagementEmail>> SelectSingleAsync(ManagementEmailSelectDto Model);
    }
}