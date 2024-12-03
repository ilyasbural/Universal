namespace Universal.Core
{
    public class SurveyRegisterDto
    {
        public string Name { get; set; } = String.Empty;
    }

    public class SurveyUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }

    public class SurveyDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class SurveySelectDto
    {
        public Guid Id { get; set; }
    }
}