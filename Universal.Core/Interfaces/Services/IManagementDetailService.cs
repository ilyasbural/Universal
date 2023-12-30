namespace Universal.Core
{
    public interface IManagementDetailService
    {
        Task<Response<ManagementDetail>> InsertAsync(ManagementDetailRegisterDto Model);
        Task<Response<ManagementDetail>> SelectAsync();
    }
}