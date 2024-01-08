namespace Universal.Core
{
    public class MessageBox : Base<MessageBox>, IEntity
    {
        public string Name { get; set; } = String.Empty;

        public MessageBox()
        {

        }
    }
}