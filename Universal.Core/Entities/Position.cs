namespace Universal.Core
{
    public class Position : Base<Position>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public Position()
        {

        }
    }
}