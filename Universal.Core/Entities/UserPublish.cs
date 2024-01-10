namespace Universal.Core
{
    public class UserPublish : Base<UserPublish>, IEntity
    {
        public User User { get; set; } = null!;

        public UserPublish()
        {

        }
    }
}