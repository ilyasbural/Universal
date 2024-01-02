namespace Universal.Core
{
    public interface IJobPostingApplyService
    {
        Task<Response<JobPostingApply>> InsertAsync(JobPostingApplyRegisterDto Model);
        Task<Response<JobPostingApply>> UpdateAsync(JobPostingApplyUpdateDto Model);
        Task<Response<JobPostingApply>> DeleteAsync(JobPostingApplyDeleteDto Model);
        Task<Response<JobPostingApply>> SelectAsync(JobPostingApplySelectDto Model);
        Task<Response<JobPostingApply>> SelectSingleAsync(JobPostingApplySelectDto Model);
    }
}