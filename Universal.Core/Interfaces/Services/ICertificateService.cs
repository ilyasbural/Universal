namespace Universal.Core
{
    public interface ICertificateService
    {
        Task<Common.Response<Common.CertificateResponse>> InsertAsync(CertificateRegisterDto Model);
        Task<Common.Response<Common.CertificateResponse>> UpdateAsync(CertificateUpdateDto Model);
        Task<Common.Response<Common.CertificateResponse>> DeleteAsync(CertificateDeleteDto Model);
        Task<Common.Response<Common.CertificateResponse>> SelectAsync(CertificateSelectDto Model);
        Task<Common.Response<Common.CertificateResponse>> SelectSingleAsync(CertificateSelectDto Model);
    }
}