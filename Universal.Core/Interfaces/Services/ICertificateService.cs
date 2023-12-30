namespace Universal.Core
{
    public interface ICertificateService
    {
        Task<Response<Certificate>> InsertAsync(CertificateRegisterDto Model);
        Task<Response<Certificate>> SelectAsync();
    }
}