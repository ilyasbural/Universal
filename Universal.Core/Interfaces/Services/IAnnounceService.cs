namespace Universal.Core
{
    public interface IAnnounceService
    {
        Task<Common.Response<Common.AnnounceResponse>> InsertAsync(AnnounceRegisterDto Model);
        Task<Common.Response<Common.AnnounceResponse>> UpdateAsync(AnnounceUpdateDto Model);
        Task<Common.Response<Common.AnnounceResponse>> DeleteAsync(AnnounceDeleteDto Model);
        Task<Common.Response<Common.AnnounceResponse>> SelectAsync(AnnounceSelectDto Model);
        Task<Common.Response<Common.AnnounceResponse>> SelectSingleAsync(AnnounceSelectDto Model);
    }
}