namespace Universal.Core
{
    public interface ICompanySettingsService
    {
        Task<Common.Response<Common.CompanySettingsResponse>> InsertAsync(CompanySettingsRegisterDto Model);
        Task<Common.Response<Common.CompanySettingsResponse>> UpdateAsync(CompanySettingsUpdateDto Model);
        Task<Common.Response<Common.CompanySettingsResponse>> DeleteAsync(CompanySettingsDeleteDto Model);
        Task<Common.Response<Common.CompanySettingsResponse>> SelectAsync(CompanySettingsSelectDto Model);
        Task<Common.Response<Common.CompanySettingsResponse>> SelectSingleAsync(CompanySettingsSelectDto Model);
    }
}