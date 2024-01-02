namespace Universal.Core
{
    public interface ISurveyService
    {
        Task<Response<Survey>> InsertAsync(SurveyRegisterDto Model);
        Task<Response<Survey>> UpdateAsync(SurveyUpdateDto Model);
        Task<Response<Survey>> DeleteAsync(SurveyDeleteDto Model);
        Task<Response<Survey>> SelectAsync(SurveySelectDto Model);
        Task<Response<Survey>> SelectSingleAsync(SurveySelectDto Model);
    }
}