namespace Universal.Core
{
    public class UserRegisterDto
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }

    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }

    public class UserDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserSelectDto
    {
        public Guid Id { get; set; }
    }
}