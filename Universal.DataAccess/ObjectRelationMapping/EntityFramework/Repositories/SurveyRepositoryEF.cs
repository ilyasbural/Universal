namespace Universal.DataAccess
{
    public class SurveyRepositoryEF : RepositoryBase<Core.Survey>, Core.ISurvey
    {
        public SurveyRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}