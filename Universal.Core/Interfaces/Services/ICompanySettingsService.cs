namespace Universal.Core
{
    public interface ICompanySettingsService
    {
        Task<Response<CompanySettings>> InsertAsync(CompanySettingsRegisterDto Model);
        Task<Response<CompanySettings>> UpdateAsync(CompanySettingsUpdateDto Model);
        Task<Response<CompanySettings>> DeleteAsync(CompanySettingsDeleteDto Model);
        Task<Response<CompanySettings>> SelectAsync(CompanySettingsSelectDto Model);
        Task<Response<CompanySettings>> SelectSingleAsync(CompanySettingsSelectDto Model);
    }
}