namespace Universal.DataAccess
{
    public class UserExperienceRepositoryEF : RepositoryBase<Core.UserExperience>, Core.IUserExperience
    {
        public UserExperienceRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}