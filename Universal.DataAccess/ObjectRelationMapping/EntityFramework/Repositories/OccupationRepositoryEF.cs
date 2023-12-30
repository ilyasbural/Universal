namespace Universal.DataAccess
{
    public class OccupationRepositoryEF : RepositoryBase<Core.Occupation>, Core.IOccupation
    {
        public OccupationRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}