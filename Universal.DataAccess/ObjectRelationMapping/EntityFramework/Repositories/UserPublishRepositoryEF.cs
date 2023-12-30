namespace Universal.DataAccess
{
    public class UserPublishRepositoryEF : RepositoryBase<Core.UserPublish>, Core.IUserPublish
    {
        public UserPublishRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}