namespace Universal.Core
{
    public interface IUserCertificateService
    {
        Task<Response<UserCertificate>> InsertAsync(UserCertificateRegisterDto Model);
        Task<Response<UserCertificate>> UpdateAsync(UserCertificateUpdateDto Model);
        Task<Response<UserCertificate>> DeleteAsync(UserCertificateDeleteDto Model);
        Task<Response<UserCertificate>> SelectAsync(UserCertificateSelectDto Model);
        Task<Response<UserCertificate>> SelectSingleAsync(UserCertificateSelectDto Model);
    }
}