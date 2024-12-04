namespace Universal.Core
{
    public interface IManagementContactService
    {
        Task<Common.Response<Common.ManagementContactResponse>> InsertAsync(ManagementContactRegisterDto Model);
        Task<Common.Response<Common.ManagementContactResponse>> UpdateAsync(ManagementContactUpdateDto Model);
        Task<Common.Response<Common.ManagementContactResponse>> DeleteAsync(ManagementContactDeleteDto Model);
        Task<Common.Response<Common.ManagementContactResponse>> SelectAsync(ManagementContactSelectDto Model);
        Task<Common.Response<Common.ManagementContactResponse>> SelectSingleAsync(ManagementContactSelectDto Model);
    }
}