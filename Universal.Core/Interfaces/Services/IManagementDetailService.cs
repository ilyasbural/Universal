namespace Universal.Core
{
    public interface IManagementDetailService
    {
        Task<Response<ManagementDetail>> InsertAsync(ManagementDetailRegisterDto Model);
        Task<Response<ManagementDetail>> UpdateAsync(ManagementDetailUpdateDto Model);
        Task<Response<ManagementDetail>> DeleteAsync(ManagementDetailDeleteDto Model);
        Task<Response<ManagementDetail>> SelectAsync(ManagementDetailSelectDto Model);
        Task<Response<ManagementDetail>> SelectSingleAsync(ManagementDetailSelectDto Model);
    }
}