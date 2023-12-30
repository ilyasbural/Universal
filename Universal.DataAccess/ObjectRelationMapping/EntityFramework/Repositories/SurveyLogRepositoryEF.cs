namespace Universal.DataAccess
{
    public class SurveyLogRepositoryEF : RepositoryBase<Core.SurveyLog>, Core.ISurveyLog
    {
        public SurveyLogRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}