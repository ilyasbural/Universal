namespace Universal.Core
{
    public class Language : Base<Language>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public Language()
        {

        }
    }
}