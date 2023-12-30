namespace Universal.Core
{
    public interface IRegionService
    {
        Task<Response<Region>> InsertAsync(RegionRegisterDto Model);
        Task<Response<Region>> SelectAsync();
    }
}