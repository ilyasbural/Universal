namespace Universal.Core
{
    public class UserSettings : Base<UserSettings>, IEntity
    {
        public User User { get; set; } = null!;

        public UserSettings()
        {

        }
    }
}