namespace Universal.DataAccess
{
    public class UserReferanceRepositoryEF : RepositoryBase<Core.UserReferance>, Core.IUserReferance
    {
        public UserReferanceRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}