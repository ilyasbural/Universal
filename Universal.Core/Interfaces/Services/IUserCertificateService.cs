namespace Universal.Core
{
    public interface IUserCertificateService
    {
        Task<Response<UserCertificate>> InsertAsync(UserCertificateRegisterDto Model);
        Task<Response<UserCertificate>> SelectAsync();
    }
}