namespace Universal.DataAccess
{
    public class ManagementRepositoryEF : RepositoryBase<Core.Management>, Core.IManagement
    {
        public ManagementRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}