namespace Universal.Core
{
    public interface IAnnounceDetailService
    {
        Task<Common.Response<Common.AnnounceDetailResponse>> InsertAsync(AnnounceDetailRegisterDto Model);
        Task<Common.Response<Common.AnnounceDetailResponse>> UpdateAsync(AnnounceDetailUpdateDto Model);
        Task<Common.Response<Common.AnnounceDetailResponse>> DeleteAsync(AnnounceDetailDeleteDto Model);
        Task<Common.Response<Common.AnnounceDetailResponse>> SelectAsync(AnnounceDetailSelectDto Model);
        Task<Common.Response<Common.AnnounceDetailResponse>> SelectSingleAsync(AnnounceDetailSelectDto Model);
    }
}