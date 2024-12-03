namespace Universal.Core
{
    public class JobPostingDetail : Base<JobPostingDetail>, IEntity
    {
        public JobPosting JobPosting { get; set; } = null!;

        public JobPostingDetail()
        {

        }
    }
}