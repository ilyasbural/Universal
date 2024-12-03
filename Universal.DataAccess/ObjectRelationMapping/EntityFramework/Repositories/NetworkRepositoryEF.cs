namespace Universal.DataAccess
{
    public class NetworkRepositoryEF : RepositoryBase<Core.Network>, Core.INetwork
    {
        public NetworkRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}