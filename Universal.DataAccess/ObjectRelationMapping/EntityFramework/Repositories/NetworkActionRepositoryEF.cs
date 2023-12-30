namespace Universal.DataAccess
{
    public class NetworkActionRepositoryEF : RepositoryBase<Core.NetworkAction>, Core.INetworkAction
    {
        public NetworkActionRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}