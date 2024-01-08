namespace Universal.Core
{
    public class CompanyRegisterDto
    {

    }

    public class CompanyUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }

    public class CompanyDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class CompanySelectDto
    {
        public Guid Id { get; set; }
    }
}