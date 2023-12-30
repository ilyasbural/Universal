namespace Universal.Core
{
    public interface IJobPostingService
    {
        Task<Response<JobPosting>> InsertAsync(JobPostingRegisterDto Model);
        Task<Response<JobPosting>> SelectAsync();
    }
}