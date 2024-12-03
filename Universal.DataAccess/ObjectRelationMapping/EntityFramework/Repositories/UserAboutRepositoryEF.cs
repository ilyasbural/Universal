namespace Universal.DataAccess
{
    public class UserAboutRepositoryEF : RepositoryBase<Core.UserAbout>, Core.IUserAbout
    {
        public UserAboutRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}