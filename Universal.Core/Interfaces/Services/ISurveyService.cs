namespace Universal.Core
{
    public interface ISurveyService
    {
        Task<Response<Survey>> InsertAsync(SurveyRegisterDto Model);
        Task<Response<Survey>> SelectAsync();
    }
}