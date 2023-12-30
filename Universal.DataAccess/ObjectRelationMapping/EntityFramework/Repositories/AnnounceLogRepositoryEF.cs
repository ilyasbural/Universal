namespace Universal.DataAccess
{
    public class AnnounceLogRepositoryEF : RepositoryBase<Core.AnnounceLog>, Core.IAnnounceLog
    {
        public AnnounceLogRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}