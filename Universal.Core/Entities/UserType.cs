namespace Universal.Core
{
    public class UserType : Base<UserType>, IEntity
    {
        public User User { get; set; } = null!;

        public UserType()
        {

        }
    }
}