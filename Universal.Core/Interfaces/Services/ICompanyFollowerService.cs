namespace Universal.Core
{
    public interface ICompanyFollowerService
    {
        Task<Response<CompanyFollower>> InsertAsync(CompanyFollowerRegisterDto Model);
        Task<Response<CompanyFollower>> UpdateAsync(CompanyFollowerUpdateDto Model);
        Task<Response<CompanyFollower>> DeleteAsync(CompanyFollowerDeleteDto Model);
        Task<Response<CompanyFollower>> SelectAsync(CompanyFollowerSelectDto Model);
        Task<Response<CompanyFollower>> SelectSingleAsync(CompanyFollowerSelectDto Model);
    }
}