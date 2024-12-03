namespace Universal.Core
{
    public class UserTypeRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserTypeUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserTypeDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserTypeSelectDto
    {
        public Guid Id { get; set; }
    }
}