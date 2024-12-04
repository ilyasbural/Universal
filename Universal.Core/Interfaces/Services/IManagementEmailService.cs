namespace Universal.Core
{
    public interface IManagementEmailService
    {
        Task<Common.Response<Common.ManagementEmailResponse>> InsertAsync(ManagementEmailRegisterDto Model);
        Task<Common.Response<Common.ManagementEmailResponse>> UpdateAsync(ManagementEmailUpdateDto Model);
        Task<Common.Response<Common.ManagementEmailResponse>> DeleteAsync(ManagementEmailDeleteDto Model);
        Task<Common.Response<Common.ManagementEmailResponse>> SelectAsync(ManagementEmailSelectDto Model);
        Task<Common.Response<Common.ManagementEmailResponse>> SelectSingleAsync(ManagementEmailSelectDto Model);
    }
}