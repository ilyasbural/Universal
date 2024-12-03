namespace Universal.Core
{
    public class Ability : Base<Ability>, IEntity
    {
        public string Name { get; set; } = string.Empty;

        public Ability()
        {

        }
    }
}