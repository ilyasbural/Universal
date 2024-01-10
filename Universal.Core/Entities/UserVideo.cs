namespace Universal.Core
{
    public class UserVideo : Base<UserVideo>, IEntity
    {
        public User User { get; set; } = null!;

        public UserVideo()
        {

        }
    }
}