namespace Universal.DataAccess
{
    public class UserVideoRepositoryEF : RepositoryBase<Core.UserVideo>, Core.IUserVideo
    {
        public UserVideoRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}