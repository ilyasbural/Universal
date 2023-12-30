namespace Universal.Core
{
    public interface ICompanyFollowerService
    {
        Task<Response<CompanyFollower>> InsertAsync(CompanyFollowerRegisterDto Model);
        Task<Response<CompanyFollower>> SelectAsync();
    }
}