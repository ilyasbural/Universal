namespace Universal.Core
{
    public interface IOccupationService
    {
        Task<Response<Occupation>> InsertAsync(OccupationRegisterDto Model);
        Task<Response<Occupation>> SelectAsync();
    }
}