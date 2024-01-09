namespace Universal.Core
{
    public class UserCountry : Base<UserCountry>, IEntity
    {
        public User User { get; set; } = null!;
        public Country Country { get; set; } = null!;

        public UserCountry()
        {

        }
    }
}