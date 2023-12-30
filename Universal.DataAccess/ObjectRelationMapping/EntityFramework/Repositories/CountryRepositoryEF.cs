namespace Universal.DataAccess
{
    public class CountryRepositoryEF : RepositoryBase<Core.Country>, Core.ICountry
    {
        public CountryRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}