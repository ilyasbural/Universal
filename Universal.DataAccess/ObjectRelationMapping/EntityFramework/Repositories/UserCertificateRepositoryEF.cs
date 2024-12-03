namespace Universal.DataAccess
{
    public class UserCertificateRepositoryEF : RepositoryBase<Core.UserCertificate>, Core.IUserCertificate
    {
        public UserCertificateRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}