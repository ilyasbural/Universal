namespace Universal.Core
{
    public class UserProject : Base<UserProject>, IEntity
    {
        public User User { get; set; } = null!;

        public UserProject()
        {

        }
    }
}