namespace Universal.DataAccess
{
    public class UserTypeRepositoryEF : RepositoryBase<Core.UserType>, Core.IUserType
    {
        public UserTypeRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}