namespace Universal.Core
{
    public class AnnounceLog : Base<AnnounceLog>, IEntity
    {
        public String Note { get; set; } = String.Empty;

        public AnnounceLog()
        {

        }
    }
}