namespace Universal.Core
{
    public class AnnounceLog : Base<AnnounceLog>, IEntity
    {
        public string Note { get; set; } = String.Empty;

        public AnnounceLog()
        {

        }
    }
}