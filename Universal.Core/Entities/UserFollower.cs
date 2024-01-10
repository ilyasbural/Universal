namespace Universal.Core
{
    public class UserFollower : Base<UserFollower>, IEntity
    {
        public User User { get; set; } = null!;
        public User Follower { get; set; } = null!;

        public UserFollower()
        {

        }
    }
}