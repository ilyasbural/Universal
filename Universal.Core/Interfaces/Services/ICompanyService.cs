namespace Universal.Core
{
    public interface ICompanyService
    {
        Task<Common.Response<Common.CompanyResponse>> InsertAsync(CompanyRegisterDto Model);
        Task<Common.Response<Common.CompanyResponse>> UpdateAsync(CompanyUpdateDto Model);
        Task<Common.Response<Common.CompanyResponse>> DeleteAsync(CompanyDeleteDto Model);
        Task<Common.Response<Common.CompanyResponse>> SelectAsync(CompanySelectDto Model);
        Task<Common.Response<Common.CompanyResponse>> SelectSingleAsync(CompanySelectDto Model);
    }
}