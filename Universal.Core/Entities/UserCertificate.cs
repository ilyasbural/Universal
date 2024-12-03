namespace Universal.Core
{
    public class UserCertificate : Base<UserCertificate>, IEntity
    {
        public User User { get; set; } = null!;
        public Certificate Certificate { get; set; } = null!;

        public UserCertificate()
        {

        }
    }
}