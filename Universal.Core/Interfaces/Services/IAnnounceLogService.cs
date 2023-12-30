namespace Universal.Core
{
    public interface IAnnounceLogService
    {
        Task<Response<AnnounceLog>> InsertAsync(AnnounceLogRegisterDto Model);
        Task<Response<AnnounceLog>> SelectAsync();
    }
}