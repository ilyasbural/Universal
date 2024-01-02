namespace Universal.Core
{
    public interface ICompanyDetailService
    {
        Task<Response<CompanyDetail>> InsertAsync(CompanyDetailRegisterDto Model);
        Task<Response<CompanyDetail>> UpdateAsync(CompanyDetailUpdateDto Model);
        Task<Response<CompanyDetail>> DeleteAsync(CompanyDetailDeleteDto Model);
        Task<Response<CompanyDetail>> SelectAsync(CompanyDetailSelectDto Model);
        Task<Response<CompanyDetail>> SelectSingleAsync(CompanyDetailSelectDto Model);
    }
}