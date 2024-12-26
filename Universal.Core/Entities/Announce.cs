namespace Universal.Core
{
    public class Announce : Base<Announce>, IEntity
    {
        public String Name { get; set; } = String.Empty;

        public Announce()
        {

        }
    }
}