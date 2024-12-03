namespace Universal.Core
{
    public interface IJobPostingService
    {
        Task<Response<JobPosting>> InsertAsync(JobPostingRegisterDto Model);
        Task<Response<JobPosting>> UpdateAsync(JobPostingUpdateDto Model);
        Task<Response<JobPosting>> DeleteAsync(JobPostingDeleteDto Model);
        Task<Response<JobPosting>> SelectAsync(JobPostingSelectDto Model);
        Task<Response<JobPosting>> SelectSingleAsync(JobPostingSelectDto Model);
    }
}