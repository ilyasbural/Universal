namespace Universal.Core
{
    public interface IManagementContactService
    {
        Task<Response<ManagementContact>> InsertAsync(ManagementContactRegisterDto Model);
        Task<Response<ManagementContact>> UpdateAsync(ManagementContactUpdateDto Model);
        Task<Response<ManagementContact>> DeleteAsync(ManagementContactDeleteDto Model);
        Task<Response<ManagementContact>> SelectAsync(ManagementContactSelectDto Model);
        Task<Response<ManagementContact>> SelectSingleAsync(ManagementContactSelectDto Model);
    }
}