namespace Universal.DataAccess
{
    public class NetworkDetailRepositoryEF : RepositoryBase<Core.NetworkDetail>, Core.INetworkDetail
    {
        public NetworkDetailRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}