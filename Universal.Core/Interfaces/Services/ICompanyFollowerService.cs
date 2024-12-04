namespace Universal.Core
{
    public interface ICompanyFollowerService
    {
        Task<Common.Response<Common.CompanyFollowerResponse>> InsertAsync(CompanyFollowerRegisterDto Model);
        Task<Common.Response<Common.CompanyFollowerResponse>> UpdateAsync(CompanyFollowerUpdateDto Model);
        Task<Common.Response<Common.CompanyFollowerResponse>> DeleteAsync(CompanyFollowerDeleteDto Model);
        Task<Common.Response<Common.CompanyFollowerResponse>> SelectAsync(CompanyFollowerSelectDto Model);
        Task<Common.Response<Common.CompanyFollowerResponse>> SelectSingleAsync(CompanyFollowerSelectDto Model);
    }
}