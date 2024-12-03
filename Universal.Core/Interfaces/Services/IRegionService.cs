namespace Universal.Core
{
    public interface IRegionService
    {
        Task<Response<Region>> InsertAsync(RegionRegisterDto Model);
        Task<Response<Region>> UpdateAsync(RegionUpdateDto Model);
        Task<Response<Region>> DeleteAsync(RegionDeleteDto Model);
        Task<Response<Region>> SelectAsync(RegionSelectDto Model);
        Task<Response<Region>> SelectSingleAsync(RegionSelectDto Model);
    }
}