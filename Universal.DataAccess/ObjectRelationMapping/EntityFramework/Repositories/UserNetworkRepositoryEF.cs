namespace Universal.DataAccess
{
    public class UserNetworkRepositoryEF : RepositoryBase<Core.UserNetwork>, Core.IUserNetwork
    {
        public UserNetworkRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}