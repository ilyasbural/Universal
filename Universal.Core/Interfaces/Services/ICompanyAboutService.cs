namespace Universal.Core
{
    public interface ICompanyAboutService
    {
        Task<Response<CompanyAbout>> InsertAsync(CompanyAboutRegisterDto Model);
        Task<Response<CompanyAbout>> SelectAsync();
    }
}