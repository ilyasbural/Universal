namespace Universal.Core
{
    public class NetworkDetail : Base<NetworkDetail>, IEntity
    {
        public Network Network { get; set; } = null!;

        public NetworkDetail()
        {

        }
    }
}