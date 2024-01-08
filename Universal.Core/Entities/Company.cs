namespace Universal.Core
{
    public class Company : Base<Company>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public Company()
        {

        }
    }
}