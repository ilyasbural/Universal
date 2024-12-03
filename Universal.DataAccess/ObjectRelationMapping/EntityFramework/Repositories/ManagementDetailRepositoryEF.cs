namespace Universal.DataAccess
{
    public class ManagementDetailRepositoryEF : RepositoryBase<Core.ManagementDetail>, Core.IManagementDetail
    {
        public ManagementDetailRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}