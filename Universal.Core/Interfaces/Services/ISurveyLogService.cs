namespace Universal.Core
{
    public interface ISurveyLogService
    {
        Task<Common.Response<Common.SurveyLogResponse>> InsertAsync(SurveyLogRegisterDto Model);
        Task<Common.Response<Common.SurveyLogResponse>> UpdateAsync(SurveyLogUpdateDto Model);
        Task<Common.Response<Common.SurveyLogResponse>> DeleteAsync(SurveyLogDeleteDto Model);
        Task<Common.Response<Common.SurveyLogResponse>> SelectAsync(SurveyLogSelectDto Model);
        Task<Common.Response<Common.SurveyLogResponse>> SelectSingleAsync(SurveyLogSelectDto Model);
    }
}