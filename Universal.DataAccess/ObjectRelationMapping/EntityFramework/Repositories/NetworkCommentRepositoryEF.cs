namespace Universal.DataAccess
{
    public class NetworkCommentRepositoryEF : RepositoryBase<Core.NetworkComment>, Core.INetworkComment
    {
        public NetworkCommentRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}