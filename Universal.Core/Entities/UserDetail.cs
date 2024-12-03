namespace Universal.Core
{
    public class UserDetail : Base<UserDetail>, IEntity
    {
        public User User { get; set; } = null!;

        public UserDetail()
        {

        }
    }
}