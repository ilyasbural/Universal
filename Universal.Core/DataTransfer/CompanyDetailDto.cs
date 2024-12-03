namespace Universal.Core
{
    public class CompanyDetailRegisterDto
    {

    }

    public class CompanyDetailUpdateDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = String.Empty;
    }

    public class CompanyDetailDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class CompanyDetailSelectDto
    {
        public Guid Id { get; set; }
    }
}