namespace Universal.Core
{
    public class UserExperience : Base<UserExperience>, IEntity
    {
        public User User { get; set; } = null!;

        public UserExperience()
        {

        }
    }
}