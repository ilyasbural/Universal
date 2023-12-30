namespace Universal.Core
{
    public interface ISurveyHistoryService
    {
        Task<Response<SurveyHistory>> InsertAsync(SurveyHistoryRegisterDto Model);
        Task<Response<SurveyHistory>> SelectAsync();
    }
}