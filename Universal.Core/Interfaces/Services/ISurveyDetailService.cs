namespace Universal.Core
{
    public interface ISurveyDetailService
    {
        Task<Response<SurveyDetail>> InsertAsync(SurveyDetailRegisterDto Model);
        Task<Response<SurveyDetail>> UpdateAsync(SurveyDetailUpdateDto Model);
        Task<Response<SurveyDetail>> DeleteAsync(SurveyDetailDeleteDto Model);
        Task<Response<SurveyDetail>> SelectAsync(SurveyDetailSelectDto Model);
        Task<Response<SurveyDetail>> SelectSingleAsync(SurveyDetailSelectDto Model);
    }
}