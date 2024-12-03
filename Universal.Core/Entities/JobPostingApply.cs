namespace Universal.Core
{
    public class JobPostingApply : Base<JobPostingApply>, IEntity
    {
        public JobPosting JobPosting { get; set; } = null!;

        public JobPostingApply()
        {

        }
    }
}