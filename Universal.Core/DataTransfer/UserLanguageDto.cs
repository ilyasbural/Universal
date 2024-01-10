namespace Universal.Core
{
    public class UserLanguageRegisterDto
    {
        public Guid UserId { get; set; }
        public Guid LanguageId { get; set; }
    }

    public class UserLanguageUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserLanguageDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserLanguageSelectDto
    {
        public Guid Id { get; set; }
    }
}