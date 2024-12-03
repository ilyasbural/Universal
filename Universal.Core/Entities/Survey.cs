namespace Universal.Core
{
    public class Survey : Base<Survey>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public Survey()
        {

        }
    }
}