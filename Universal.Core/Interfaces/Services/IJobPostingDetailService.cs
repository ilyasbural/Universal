namespace Universal.Core
{
    public interface IJobPostingDetailService
    {
        Task<Common.Response<Common.JobPostingDetailResponse>> InsertAsync(JobPostingDetailRegisterDto Model);
        Task<Common.Response<Common.JobPostingDetailResponse>> UpdateAsync(JobPostingDetailUpdateDto Model);
        Task<Common.Response<Common.JobPostingDetailResponse>> DeleteAsync(JobPostingDetailDeleteDto Model);
        Task<Common.Response<Common.JobPostingDetailResponse>> SelectAsync(JobPostingDetailSelectDto Model);
        Task<Common.Response<Common.JobPostingDetailResponse>> SelectSingleAsync(JobPostingDetailSelectDto Model);
    }
}