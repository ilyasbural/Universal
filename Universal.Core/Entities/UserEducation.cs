namespace Universal.Core
{
    public class UserEducation : Base<UserEducation>, IEntity
    {
        public User User { get; set; } = null!;

        public UserEducation()
        {

        }
    }
}