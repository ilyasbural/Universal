namespace Universal.Core
{
    public class Certificate : Base<Certificate>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public Certificate()
        {

        }
    }
}