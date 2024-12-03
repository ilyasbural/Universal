namespace Universal.Core
{
    public interface IOccupationService
    {
        Task<Response<Occupation>> InsertAsync(OccupationRegisterDto Model);
        Task<Response<Occupation>> UpdateAsync(OccupationUpdateDto Model);
        Task<Response<Occupation>> DeleteAsync(OccupationDeleteDto Model);
        Task<Response<Occupation>> SelectAsync(OccupationSelectDto Model);
        Task<Response<Occupation>> SelectSingleAsync(OccupationSelectDto Model);
    }
}