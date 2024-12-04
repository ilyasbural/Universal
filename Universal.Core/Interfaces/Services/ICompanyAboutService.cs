namespace Universal.Core
{
    public interface ICompanyAboutService
    {
        Task<Common.Response<Common.CompanyAboutResponse>> InsertAsync(CompanyAboutRegisterDto Model);
        Task<Common.Response<Common.CompanyAboutResponse>> UpdateAsync(CompanyAboutUpdateDto Model);
        Task<Common.Response<Common.CompanyAboutResponse>> DeleteAsync(CompanyAboutDeleteDto Model);
        Task<Common.Response<Common.CompanyAboutResponse>> SelectAsync(CompanyAboutSelectDto Model);
        Task<Common.Response<Common.CompanyAboutResponse>> SelectSingleAsync(CompanyAboutSelectDto Model);
    }
}