namespace Universal.Core
{
    public class User : Base<User>, IEntity
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;

        public User()
        {

        }
    }
}