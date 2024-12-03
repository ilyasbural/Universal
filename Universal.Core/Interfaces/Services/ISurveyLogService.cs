namespace Universal.Core
{
    public interface ISurveyLogService
    {
        Task<Response<SurveyLog>> InsertAsync(SurveyLogRegisterDto Model);
        Task<Response<SurveyLog>> UpdateAsync(SurveyLogUpdateDto Model);
        Task<Response<SurveyLog>> DeleteAsync(SurveyLogDeleteDto Model);
        Task<Response<SurveyLog>> SelectAsync(SurveyLogSelectDto Model);
        Task<Response<SurveyLog>> SelectSingleAsync(SurveyLogSelectDto Model);
    }
}