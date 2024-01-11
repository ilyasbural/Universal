namespace Universal.Core
{
    public class NetworkComment : Base<NetworkComment>, IEntity
    {
        public Network Network { get; set; } = null!;

        public NetworkComment()
        {

        }
    }
}