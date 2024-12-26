namespace Universal.Core
{
    public class Certificate : Base<Certificate>, IEntity
    {
        public String Name { get; set; } = String.Empty;

        public Certificate()
        {

        }
    }
}