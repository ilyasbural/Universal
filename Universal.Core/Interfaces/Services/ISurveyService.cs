namespace Universal.Core
{
    public interface ISurveyService
    {
        Task<Common.Response<Common.SurveyResponse>> InsertAsync(SurveyRegisterDto Model);
        Task<Common.Response<Common.SurveyResponse>> UpdateAsync(SurveyUpdateDto Model);
        Task<Common.Response<Common.SurveyResponse>> DeleteAsync(SurveyDeleteDto Model);
        Task<Common.Response<Common.SurveyResponse>> SelectAsync(SurveySelectDto Model);
        Task<Common.Response<Common.SurveyResponse>> SelectSingleAsync(SurveySelectDto Model);
    }
}