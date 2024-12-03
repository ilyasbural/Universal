namespace Universal.Core
{
    public class LanguageRegisterDto
    {

    }

    public class LanguageUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class LanguageDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class LanguageSelectDto
    {
        public Guid Id { get; set; }
    }
}