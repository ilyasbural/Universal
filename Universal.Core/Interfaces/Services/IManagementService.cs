namespace Universal.Core
{
    public interface IManagementService
    {
        Task<Common.Response<Common.ManagementResponse>> InsertAsync(ManagementRegisterDto Model);
        Task<Common.Response<Common.ManagementResponse>> UpdateAsync(ManagementUpdateDto Model);
        Task<Common.Response<Common.ManagementResponse>> DeleteAsync(ManagementDeleteDto Model);
        Task<Common.Response<Common.ManagementResponse>> SelectAsync(ManagementSelectDto Model);
        Task<Common.Response<Common.ManagementResponse>> SelectSingleAsync(ManagementSelectDto Model);
    }
}