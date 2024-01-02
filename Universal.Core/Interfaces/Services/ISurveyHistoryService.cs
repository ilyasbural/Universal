namespace Universal.Core
{
    public interface ISurveyHistoryService
    {
        Task<Response<SurveyHistory>> InsertAsync(SurveyHistoryRegisterDto Model);
        Task<Response<SurveyHistory>> UpdateAsync(SurveyHistoryUpdateDto Model);
        Task<Response<SurveyHistory>> DeleteAsync(SurveyHistoryDeleteDto Model);
        Task<Response<SurveyHistory>> SelectAsync(SurveyHistorySelectDto Model);
        Task<Response<SurveyHistory>> SelectSingleAsync(SurveyHistorySelectDto Model);
    }
}