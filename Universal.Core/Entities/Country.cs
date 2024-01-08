namespace Universal.Core
{
    public class Country : Base<Country>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public Country()
        {

        }
    }
}