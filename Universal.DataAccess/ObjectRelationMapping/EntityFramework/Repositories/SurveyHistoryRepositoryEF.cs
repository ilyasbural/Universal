namespace Universal.DataAccess
{
    public class SurveyHistoryRepositoryEF : RepositoryBase<Core.SurveyHistory>, Core.ISurveyHistory
    {
        public SurveyHistoryRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}