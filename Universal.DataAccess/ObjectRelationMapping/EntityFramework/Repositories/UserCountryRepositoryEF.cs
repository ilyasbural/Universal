namespace Universal.DataAccess
{
    public class UserCountryRepositoryEF : RepositoryBase<Core.UserCountry>, Core.IUserCountry
    {
        public UserCountryRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}