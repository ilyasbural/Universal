namespace Universal.Core
{
    public class UserCertificateRegisterDto
    {
        public Guid UserId { get; set; }
        public Guid CertificateId { get; set; }
    }

    public class UserCertificateUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid CertificateId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserCertificateDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserCertificateSelectDto
    {
        public Guid Id { get; set; }
    }
}