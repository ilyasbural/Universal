namespace Universal.Core
{
    public interface ICompanyDetailService
    {
        Task<Common.Response<Common.CompanyDetailResponse>> InsertAsync(CompanyDetailRegisterDto Model);
        Task<Common.Response<Common.CompanyDetailResponse>> UpdateAsync(CompanyDetailUpdateDto Model);
        Task<Common.Response<Common.CompanyDetailResponse>> DeleteAsync(CompanyDetailDeleteDto Model);
        Task<Common.Response<Common.CompanyDetailResponse>> SelectAsync(CompanyDetailSelectDto Model);
        Task<Common.Response<Common.CompanyDetailResponse>> SelectSingleAsync(CompanyDetailSelectDto Model);
    }
}