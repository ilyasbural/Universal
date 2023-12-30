namespace Universal.Core
{
    public interface ICompanySettingsService
    {
        Task<Response<CompanySettings>> InsertAsync(CompanySettingsRegisterDto Model);
        Task<Response<CompanySettings>> SelectAsync();
    }
}