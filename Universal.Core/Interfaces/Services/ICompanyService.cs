namespace Universal.Core
{
    public interface ICompanyService
    {
        Task<Response<Company>> InsertAsync(CompanyRegisterDto Model);
        Task<Response<Company>> SelectAsync();
    }
}