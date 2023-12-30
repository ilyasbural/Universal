namespace Universal.Core
{
    public interface IAnnounceService
    {
        Task<Response<Announce>> InsertAsync(AnnounceRegisterDto Model);
        Task<Response<Announce>> SelectAsync();
    }
}