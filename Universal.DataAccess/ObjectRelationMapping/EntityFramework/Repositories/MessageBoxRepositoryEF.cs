namespace Universal.DataAccess
{
    public class MessageBoxRepositoryEF : RepositoryBase<Core.MessageBox>, Core.IMessageBox
    {
        public MessageBoxRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}