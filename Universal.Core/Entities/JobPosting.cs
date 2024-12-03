namespace Universal.Core
{
    public class JobPosting : Base<JobPosting>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public JobPosting()
        {

        }
    }
}