namespace Universal.Core
{
    public class Ability : Base<Ability>, IEntity
    {
        public String Name { get; set; } = String.Empty;

        public Ability()
        {

        }
    }
}