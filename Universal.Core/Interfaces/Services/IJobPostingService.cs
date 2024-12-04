namespace Universal.Core
{
    public interface IJobPostingService
    {
        Task<Common.Response<Common.JobPostingResponse>> InsertAsync(JobPostingRegisterDto Model);
        Task<Common.Response<Common.JobPostingResponse>> UpdateAsync(JobPostingUpdateDto Model);
        Task<Common.Response<Common.JobPostingResponse>> DeleteAsync(JobPostingDeleteDto Model);
        Task<Common.Response<Common.JobPostingResponse>> SelectAsync(JobPostingSelectDto Model);
        Task<Common.Response<Common.JobPostingResponse>> SelectSingleAsync(JobPostingSelectDto Model);
    }
}