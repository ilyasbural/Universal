namespace Universal.Core
{
    public interface IManagementDetailService
    {
        Task<Common.Response<Common.ManagementDetailResponse>> InsertAsync(ManagementDetailRegisterDto Model);
        Task<Common.Response<Common.ManagementDetailResponse>> UpdateAsync(ManagementDetailUpdateDto Model);
        Task<Common.Response<Common.ManagementDetailResponse>> DeleteAsync(ManagementDetailDeleteDto Model);
        Task<Common.Response<Common.ManagementDetailResponse>> SelectAsync(ManagementDetailSelectDto Model);
        Task<Common.Response<Common.ManagementDetailResponse>> SelectSingleAsync(ManagementDetailSelectDto Model);
    }
}