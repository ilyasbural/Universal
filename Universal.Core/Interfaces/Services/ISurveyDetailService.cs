namespace Universal.Core
{
    public interface ISurveyDetailService
    {
        Task<Response<SurveyDetail>> InsertAsync(SurveyDetailRegisterDto Model);
        Task<Response<SurveyDetail>> SelectAsync();
    }
}