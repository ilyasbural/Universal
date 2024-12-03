namespace Universal.Core
{
    public class NetworkAction : Base<NetworkAction>, IEntity
    {
        public Network Network { get; set; } = null!;

        public NetworkAction()
        {

        }
    }
}