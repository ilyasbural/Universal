namespace Universal.Core
{
    public class Region : Base<Region>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public Region()
        {

        }
    }
}