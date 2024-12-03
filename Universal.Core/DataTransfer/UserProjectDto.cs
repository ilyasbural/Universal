namespace Universal.Core
{
    public class UserProjectRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserProjectUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserProjectDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserProjectSelectDto
    {
        public Guid Id { get; set; }
    }
}