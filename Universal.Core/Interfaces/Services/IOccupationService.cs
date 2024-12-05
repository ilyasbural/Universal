namespace Universal.Core
{
    public interface IOccupationService
    {
        Task<Common.Response<Common.OccupationResponse>> InsertAsync(OccupationRegisterDto Model);
        Task<Common.Response<Common.OccupationResponse>> UpdateAsync(OccupationUpdateDto Model);
        Task<Common.Response<Common.OccupationResponse>> DeleteAsync(OccupationDeleteDto Model);
        Task<Common.Response<Common.OccupationResponse>> SelectAsync(OccupationSelectDto Model);
        Task<Common.Response<Common.OccupationResponse>> SelectSingleAsync(OccupationSelectDto Model);
    }
}