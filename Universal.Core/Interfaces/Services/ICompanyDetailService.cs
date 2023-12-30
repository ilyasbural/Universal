namespace Universal.Core
{
    public interface ICompanyDetailService
    {
        Task<Response<CompanyDetail>> InsertAsync(CompanyDetailRegisterDto Model);
        Task<Response<CompanyDetail>> SelectAsync();
    }
}