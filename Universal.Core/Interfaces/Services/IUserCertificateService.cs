namespace Universal.Core
{
    public interface IUserCertificateService
    {
        Task<Common.Response<Common.UserCertificateResponse>> InsertAsync(UserCertificateRegisterDto Model);
        Task<Common.Response<Common.UserCertificateResponse>> UpdateAsync(UserCertificateUpdateDto Model);
        Task<Common.Response<Common.UserCertificateResponse>> DeleteAsync(UserCertificateDeleteDto Model);
        Task<Common.Response<Common.UserCertificateResponse>> SelectAsync(UserCertificateSelectDto Model);
        Task<Common.Response<Common.UserCertificateResponse>> SelectSingleAsync(UserCertificateSelectDto Model);
    }
}