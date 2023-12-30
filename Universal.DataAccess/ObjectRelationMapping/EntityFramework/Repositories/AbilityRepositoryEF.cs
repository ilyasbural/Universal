namespace Universal.DataAccess
{
    public class AbilityRepositoryEF : RepositoryBase<Core.Ability>, Core.IAbility
    {
        public AbilityRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}