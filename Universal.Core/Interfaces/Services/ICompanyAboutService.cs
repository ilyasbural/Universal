namespace Universal.Core
{
    public interface ICompanyAboutService
    {
        Task<Response<CompanyAbout>> InsertAsync(CompanyAboutRegisterDto Model);
        Task<Response<CompanyAbout>> UpdateAsync(CompanyAboutUpdateDto Model);
        Task<Response<CompanyAbout>> DeleteAsync(CompanyAboutDeleteDto Model);
        Task<Response<CompanyAbout>> SelectAsync(CompanyAboutSelectDto Model);
        Task<Response<CompanyAbout>> SelectSingleAsync(CompanyAboutSelectDto Model);
    }
}