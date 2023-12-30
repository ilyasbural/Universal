namespace Universal.Core
{
    public interface IAnnounceDetailService
    {
        Task<Response<AnnounceDetail>> InsertAsync(AnnounceDetailRegisterDto Model);
        Task<Response<AnnounceDetail>> SelectAsync();
    }
}