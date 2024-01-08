namespace Universal.Core
{
    public class Announce : Base<Announce>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public Announce()
        {

        }
    }
}