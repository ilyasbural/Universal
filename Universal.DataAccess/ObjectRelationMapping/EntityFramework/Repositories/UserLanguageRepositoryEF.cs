namespace Universal.DataAccess
{
    public class UserLanguageRepositoryEF : RepositoryBase<Core.UserLanguage>, Core.IUserLanguage
    {
        public UserLanguageRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}