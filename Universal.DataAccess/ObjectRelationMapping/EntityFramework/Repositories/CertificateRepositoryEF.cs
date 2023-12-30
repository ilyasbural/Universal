namespace Universal.DataAccess
{
    public class CertificateRepositoryEF : RepositoryBase<Core.Certificate>, Core.ICertificate
    {
        public CertificateRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}