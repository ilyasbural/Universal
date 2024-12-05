namespace Universal.Core
{
    public interface IRegionService
    {
        Task<Common.Response<Common.RegionResponse>> InsertAsync(RegionRegisterDto Model);
        Task<Common.Response<Common.RegionResponse>> UpdateAsync(RegionUpdateDto Model);
        Task<Common.Response<Common.RegionResponse>> DeleteAsync(RegionDeleteDto Model);
        Task<Common.Response<Common.RegionResponse>> SelectAsync(RegionSelectDto Model);
        Task<Common.Response<Common.RegionResponse>> SelectSingleAsync(RegionSelectDto Model);
    }
}