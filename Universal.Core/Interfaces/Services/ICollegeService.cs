namespace Universal.Core
{
    public interface ICollegeService
    {
        Task<Response<College>> InsertAsync(CollegeRegisterDto Model);
        Task<Response<College>> SelectAsync();
    }
}