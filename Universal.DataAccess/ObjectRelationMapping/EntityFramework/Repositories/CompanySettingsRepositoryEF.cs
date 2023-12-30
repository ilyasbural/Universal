namespace Universal.DataAccess
{
    public class CompanySettingsRepositoryEF : RepositoryBase<Core.CompanySettings>, Core.ICompanySettings
    {
        public CompanySettingsRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}