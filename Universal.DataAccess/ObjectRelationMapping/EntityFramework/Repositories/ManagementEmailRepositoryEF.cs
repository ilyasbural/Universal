namespace Universal.DataAccess
{
    public class ManagementEmailRepositoryEF : RepositoryBase<Core.ManagementEmail>, Core.IManagementEmail
    {
        public ManagementEmailRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}