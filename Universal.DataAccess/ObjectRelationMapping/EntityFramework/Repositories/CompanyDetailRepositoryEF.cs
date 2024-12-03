namespace Universal.DataAccess
{
    public class CompanyDetailRepositoryEF : RepositoryBase<Core.CompanyDetail>, Core.ICompanyDetail
    {
        public CompanyDetailRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}