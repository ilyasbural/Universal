namespace Universal.Presentation
{
    public class JobPostingDetailViewModel : BaseViewModel<JobPostingDetailViewModel>
    {
        public JobPostingViewModel JobPosting { get; set; } = new JobPostingViewModel();
    }
}