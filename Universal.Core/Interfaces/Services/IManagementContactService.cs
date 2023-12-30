namespace Universal.Core
{
    public interface IManagementContactService
    {
        Task<Response<ManagementContact>> InsertAsync(ManagementContactRegisterDto Model);
        Task<Response<ManagementContact>> SelectAsync();
    }
}