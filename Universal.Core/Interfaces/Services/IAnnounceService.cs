namespace Universal.Core
{
    public interface IAnnounceService
    {
        Task<Response<Announce>> InsertAsync(AnnounceRegisterDto Model);
        Task<Response<Announce>> UpdateAsync(AnnounceUpdateDto Model);
        Task<Response<Announce>> DeleteAsync(AnnounceDeleteDto Model);
        Task<Response<Announce>> SelectAsync(AnnounceSelectDto Model);
        Task<Response<Announce>> SelectSingleAsync(AnnounceSelectDto Model);
    }
}