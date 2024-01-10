namespace Universal.Core
{
    public class UserFollowerRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserFollowerUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserFollowerDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserFollowerSelectDto
    {
        public Guid Id { get; set; }
    }
}