namespace Universal.Core
{
    public interface IJobPostingApplyService
    {
        Task<Common.Response<Common.JobPostingApplyResponse>> InsertAsync(JobPostingApplyRegisterDto Model);
        Task<Common.Response<Common.JobPostingApplyResponse>> UpdateAsync(JobPostingApplyUpdateDto Model);
        Task<Common.Response<Common.JobPostingApplyResponse>> DeleteAsync(JobPostingApplyDeleteDto Model);
        Task<Common.Response<Common.JobPostingApplyResponse>> SelectAsync(JobPostingApplySelectDto Model);
        Task<Common.Response<Common.JobPostingApplyResponse>> SelectSingleAsync(JobPostingApplySelectDto Model);
    }
}