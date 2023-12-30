namespace Universal.Core
{
    public interface IManagementService
    {
        Task<Response<Management>> InsertAsync(ManagementRegisterDto Model);
        Task<Response<Management>> SelectAsync();
    }
}