namespace Universal.Core
{
    public interface IAnnounceDetailService
    {
        Task<Response<AnnounceDetail>> InsertAsync(AnnounceDetailRegisterDto Model);
        Task<Response<AnnounceDetail>> UpdateAsync(AnnounceDetailUpdateDto Model);
        Task<Response<AnnounceDetail>> DeleteAsync(AnnounceDetailDeleteDto Model);
        Task<Response<AnnounceDetail>> SelectAsync(AnnounceDetailSelectDto Model);
        Task<Response<AnnounceDetail>> SelectSingleAsync(AnnounceDetailSelectDto Model);
    }
}