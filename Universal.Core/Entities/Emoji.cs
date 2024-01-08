namespace Universal.Core
{
    public class Emoji : Base<Emoji>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public Emoji()
        {

        }
    }
}