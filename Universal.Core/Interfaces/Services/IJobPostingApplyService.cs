namespace Universal.Core
{
    public interface IJobPostingApplyService
    {
        Task<Response<JobPostingApply>> InsertAsync(JobPostingApplyRegisterDto Model);
        Task<Response<JobPostingApply>> SelectAsync();
    }
}