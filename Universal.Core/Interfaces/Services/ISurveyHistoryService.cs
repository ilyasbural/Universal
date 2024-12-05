namespace Universal.Core
{
    public interface ISurveyHistoryService
    {
        Task<Common.Response<Common.SurveyHistoryResponse>> InsertAsync(SurveyHistoryRegisterDto Model);
        Task<Common.Response<Common.SurveyHistoryResponse>> UpdateAsync(SurveyHistoryUpdateDto Model);
        Task<Common.Response<Common.SurveyHistoryResponse>> DeleteAsync(SurveyHistoryDeleteDto Model);
        Task<Common.Response<Common.SurveyHistoryResponse>> SelectAsync(SurveyHistorySelectDto Model);
        Task<Common.Response<Common.SurveyHistoryResponse>> SelectSingleAsync(SurveyHistorySelectDto Model);
    }
}