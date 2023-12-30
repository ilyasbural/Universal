namespace Universal.DataAccess
{
    public class SurveyDetailRepositoryEF : RepositoryBase<Core.SurveyDetail>, Core.ISurveyDetail
    {
        public SurveyDetailRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}