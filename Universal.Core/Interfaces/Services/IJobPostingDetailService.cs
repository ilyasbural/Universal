namespace Universal.Core
{
    public interface IJobPostingDetailService
    {
        Task<Response<JobPostingDetail>> InsertAsync(JobPostingDetailRegisterDto Model);
        Task<Response<JobPostingDetail>> SelectAsync();
    }
}