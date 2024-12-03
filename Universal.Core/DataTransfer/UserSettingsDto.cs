namespace Universal.Core
{
    public class UserSettingsRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserSettingsUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserSettingsDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserSettingsSelectDto
    {
        public Guid Id { get; set; }
    }
}