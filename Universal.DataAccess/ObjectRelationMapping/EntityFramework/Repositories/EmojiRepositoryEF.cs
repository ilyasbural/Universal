namespace Universal.DataAccess
{
    public class EmojiRepositoryEF : RepositoryBase<Core.Emoji>, Core.IEmoji
    {
        public EmojiRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}