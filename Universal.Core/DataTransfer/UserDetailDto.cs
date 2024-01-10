namespace Universal.Core
{
    public class UserDetailRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserDetailUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserDetailDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserDetailSelectDto
    {
        public Guid Id { get; set; }
    }
}