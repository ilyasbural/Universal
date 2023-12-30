namespace Universal.DataAccess
{
    public class RegionRepositoryEF : RepositoryBase<Core.Region>, Core.IRegion
    {
        public RegionRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}