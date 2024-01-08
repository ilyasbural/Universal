namespace Universal.Core
{
    public class AnnounceDetail : Base<AnnounceDetail>, IEntity
    {
        public string Description { get; set; } = String.Empty;

        public AnnounceDetail()
        {

        }
    }
}