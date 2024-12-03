namespace Universal.Core
{
    public interface IAnnounceLogService
    {
        Task<Response<AnnounceLog>> InsertAsync(AnnounceLogRegisterDto Model);
        Task<Response<AnnounceLog>> UpdateAsync(AnnounceLogUpdateDto Model);
        Task<Response<AnnounceLog>> DeleteAsync(AnnounceLogDeleteDto Model);
        Task<Response<AnnounceLog>> SelectAsync(AnnounceLogSelectDto Model);
        Task<Response<AnnounceLog>> SelectSingleAsync(AnnounceLogSelectDto Model);
    }
}