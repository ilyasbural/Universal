namespace Universal.Core
{
    public class UserLanguage : Base<UserLanguage>, IEntity
    {
        public User User { get; set; } = null!;
        public Language Language { get; set; } = null!;

        public UserLanguage()
        {

        }
    }
}