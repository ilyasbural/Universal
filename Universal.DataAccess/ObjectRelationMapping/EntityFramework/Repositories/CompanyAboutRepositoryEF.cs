namespace Universal.DataAccess
{
    public class CompanyAboutRepositoryEF : RepositoryBase<Core.CompanyAbout>, Core.ICompanyAbout
    {
        public CompanyAboutRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}