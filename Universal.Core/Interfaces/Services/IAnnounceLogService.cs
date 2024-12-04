namespace Universal.Core
{
    public interface IAnnounceLogService
    {
        Task<Common.Response<Common.AnnounceLogResponse>> InsertAsync(AnnounceLogRegisterDto Model);
        Task<Common.Response<Common.AnnounceLogResponse>> UpdateAsync(AnnounceLogUpdateDto Model);
        Task<Common.Response<Common.AnnounceLogResponse>> DeleteAsync(AnnounceLogDeleteDto Model);
        Task<Common.Response<Common.AnnounceLogResponse>> SelectAsync(AnnounceLogSelectDto Model);
        Task<Common.Response<Common.AnnounceLogResponse>> SelectSingleAsync(AnnounceLogSelectDto Model);
    }
}