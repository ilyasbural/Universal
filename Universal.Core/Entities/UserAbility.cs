namespace Universal.Core
{
    public class UserAbility : Base<UserAbility>, IEntity
    {
        public User User { get; set; } = new User();
        public Ability Ability { get; set; } = new Ability();

        public UserAbility()
        {

        }
    }
}