namespace Universal.Core
{
    public interface IJobPostingDetailService
    {
        Task<Response<JobPostingDetail>> InsertAsync(JobPostingDetailRegisterDto Model);
        Task<Response<JobPostingDetail>> UpdateAsync(JobPostingDetailUpdateDto Model);
        Task<Response<JobPostingDetail>> DeleteAsync(JobPostingDetailDeleteDto Model);
        Task<Response<JobPostingDetail>> SelectAsync(JobPostingDetailSelectDto Model);
        Task<Response<JobPostingDetail>> SelectSingleAsync(JobPostingDetailSelectDto Model);
    }
}