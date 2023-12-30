namespace Universal.DataAccess
{
    public class AnnounceRepositoryEF : RepositoryBase<Core.Announce>, Core.IAnnounce
    {
        public AnnounceRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}