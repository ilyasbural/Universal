namespace Universal.Core
{
    public class JobPostingDetailRegisterDto
    {
        public Guid JobPostingId { get; set; }
    }

    public class JobPostingDetailUpdateDto
    {
        public Guid JobPostingId { get; set; }
        public Guid Id { get; set; }
    }

    public class JobPostingDetailDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class JobPostingDetailSelectDto
    {
        public Guid Id { get; set; }
    }
}