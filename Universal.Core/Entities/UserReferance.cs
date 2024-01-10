namespace Universal.Core
{
    public class UserReferance : Base<UserReferance>, IEntity
    {
        public User User { get; set; } = null!;

        public UserReferance()
        {

        }
    }
}