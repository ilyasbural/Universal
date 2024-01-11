namespace Universal.Core
{
    public class JobPostingRegisterDto
    {
        public string Name { get; set; } = String.Empty;
    }

    public class JobPostingUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }

    public class JobPostingDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class JobPostingSelectDto
    {
        public Guid Id { get; set; }
    }
}