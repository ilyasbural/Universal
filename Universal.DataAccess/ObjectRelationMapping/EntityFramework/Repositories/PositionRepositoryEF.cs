namespace Universal.DataAccess
{
    public class PositionRepositoryEF : RepositoryBase<Core.Position>, Core.IPosition
    {
        public PositionRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}