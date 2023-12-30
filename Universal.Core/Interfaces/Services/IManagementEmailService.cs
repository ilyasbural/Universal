namespace Universal.Core
{
    public interface IManagementEmailService
    {
        Task<Response<ManagementEmail>> InsertAsync(ManagementEmailRegisterDto Model);
        Task<Response<ManagementEmail>> SelectAsync();
    }
}