namespace Universal.Core
{
    public interface ICollegeService
    {
        Task<Response<College>> InsertAsync(CollegeRegisterDto Model);
        Task<Response<College>> UpdateAsync(CollegeUpdateDto Model);
        Task<Response<College>> DeleteAsync(CollegeDeleteDto Model);
        Task<Response<College>> SelectAsync(CollegeSelectDto Model);
        Task<Response<College>> SelectSingleAsync(CollegeSelectDto Model);
    }
}