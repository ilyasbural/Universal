namespace Universal.DataAccess
{
    public class AnnounceDetailRepositoryEF : RepositoryBase<Core.AnnounceDetail>, Core.IAnnounceDetail
    {
        public AnnounceDetailRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}