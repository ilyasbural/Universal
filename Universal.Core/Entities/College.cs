namespace Universal.Core
{
    public class College : Base<College>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public College()
        {

        }
    }
}