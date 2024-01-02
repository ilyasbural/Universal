namespace Universal.Core
{
    public interface ICertificateService
    {
        Task<Response<Certificate>> InsertAsync(CertificateRegisterDto Model);
        Task<Response<Certificate>> UpdateAsync(CertificateUpdateDto Model);
        Task<Response<Certificate>> DeleteAsync(CertificateDeleteDto Model);
        Task<Response<Certificate>> SelectAsync(CertificateSelectDto Model);
        Task<Response<Certificate>> SelectSingleAsync(CertificateSelectDto Model);
    }
}