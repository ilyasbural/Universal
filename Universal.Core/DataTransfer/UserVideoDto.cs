namespace Universal.Core
{
    public class UserVideoRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserVideoUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserVideoDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserVideoSelectDto
    {
        public Guid Id { get; set; }
    }
}