namespace Universal.Core
{
    public interface ICollegeService
    {
        Task<Common.Response<Common.CollegeResponse>> InsertAsync(CollegeRegisterDto Model);
        Task<Common.Response<Common.CollegeResponse>> UpdateAsync(CollegeUpdateDto Model);
        Task<Common.Response<Common.CollegeResponse>> DeleteAsync(CollegeDeleteDto Model);
        Task<Common.Response<Common.CollegeResponse>> SelectAsync(CollegeSelectDto Model);
        Task<Common.Response<Common.CollegeResponse>> SelectSingleAsync(CollegeSelectDto Model);
    }
}