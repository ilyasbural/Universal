namespace Universal.Core
{
    public interface ISurveyLogService
    {
        Task<Response<SurveyLog>> InsertAsync(SurveyLogRegisterDto Model);
        Task<Response<SurveyLog>> SelectAsync();
    }
}