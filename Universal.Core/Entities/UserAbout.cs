namespace Universal.Core
{
    public class UserAbout : Base<UserAbout>, IEntity
    {
        public User User { get; set; } = null!;
        public string About { get; set; } = String.Empty;

        public UserAbout()
        {

        }
    }
}