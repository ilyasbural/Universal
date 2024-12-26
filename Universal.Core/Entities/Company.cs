namespace Universal.Core
{
    public class Company : Base<Company>, IEntity
    {
        public String Name { get; set; } = String.Empty;

        public Company()
        {

        }
    }
}