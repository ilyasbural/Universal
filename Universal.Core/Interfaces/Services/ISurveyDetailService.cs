namespace Universal.Core
{
    public interface ISurveyDetailService
    {
        Task<Common.Response<Common.SurveyDetailResponse>> InsertAsync(SurveyDetailRegisterDto Model);
        Task<Common.Response<Common.SurveyDetailResponse>> UpdateAsync(SurveyDetailUpdateDto Model);
        Task<Common.Response<Common.SurveyDetailResponse>> DeleteAsync(SurveyDetailDeleteDto Model);
        Task<Common.Response<Common.SurveyDetailResponse>> SelectAsync(SurveyDetailSelectDto Model);
        Task<Common.Response<Common.SurveyDetailResponse>> SelectSingleAsync(SurveyDetailSelectDto Model);
    }
}