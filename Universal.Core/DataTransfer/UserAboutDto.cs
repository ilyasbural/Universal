namespace Universal.Core
{
    public class UserAboutRegisterDto
    {
        public Guid UserId { get; set; }
        public string About { get; set; } = String.Empty;
    }

    public class UserAboutUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string About { get; set; } = String.Empty;
    }

    public class UserAboutDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserAboutSelectDto
    {
        public Guid Id { get; set; }
    }
}