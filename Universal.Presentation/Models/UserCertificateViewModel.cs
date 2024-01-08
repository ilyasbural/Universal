namespace Universal.Presentation
{
    public class UserCertificateViewModel : BaseViewModel<UserCertificateViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
        public CertificateViewModel Certificate { get; set; } = new CertificateViewModel();
    }
}