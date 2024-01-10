namespace Universal.Core
{
    public class UserPublishRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserPublishUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserPublishDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserPublishSelectDto
    {
        public Guid Id { get; set; }
    }
}