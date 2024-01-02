namespace Universal.Core
{
    public interface ICompanyService
    {
        Task<Response<Company>> InsertAsync(CompanyRegisterDto Model);
        Task<Response<Company>> UpdateAsync(CompanyUpdateDto Model);
        Task<Response<Company>> DeleteAsync(CompanyDeleteDto Model);
        Task<Response<Company>> SelectAsync(CompanySelectDto Model);
        Task<Response<Company>> SelectSingleAsync(CompanySelectDto Model);
    }
}