namespace Universal.Presentation
{
    public class JobPostingApplyViewModel : BaseViewModel<JobPostingApplyViewModel>
    {
        public JobPostingViewModel JobPosting { get; set; } = new JobPostingViewModel();
    }
}