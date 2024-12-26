namespace Universal.Core
{
    public class AnnounceDetail : Base<AnnounceDetail>, IEntity
    {
        public String Description { get; set; } = String.Empty;

        public AnnounceDetail()
        {

        }
    }
}