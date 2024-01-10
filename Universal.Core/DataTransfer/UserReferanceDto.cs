namespace Universal.Core
{
    public class UserReferanceRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserReferanceUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserReferanceDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserReferanceSelectDto
    {
        public Guid Id { get; set; }
    }
}