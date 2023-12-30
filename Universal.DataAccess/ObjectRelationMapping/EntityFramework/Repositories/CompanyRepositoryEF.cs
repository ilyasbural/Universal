namespace Universal.DataAccess
{
    public class CompanyRepositoryEF : RepositoryBase<Core.Company>, Core.ICompany
    {
        public CompanyRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}