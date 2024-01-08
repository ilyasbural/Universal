namespace Universal.Core
{
    public class CertificateRegisterDto
    {

    }

    public class CertificateUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }

    public class CertificateDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class CertificateSelectDto
    {
        public Guid Id { get; set; }
    }
}