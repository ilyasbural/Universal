namespace Universal.Core
{
    public class UserNetworkRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserNetworkUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserNetworkDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserNetworkSelectDto
    {
        public Guid Id { get; set; }
    }
}