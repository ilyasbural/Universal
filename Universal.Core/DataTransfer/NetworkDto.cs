namespace Universal.Core
{
    public class NetworkRegisterDto
    {
        public string Name { get; set; } = String.Empty;
    }

    public class NetworkUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }

    public class NetworkDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class NetworkSelectDto
    {
        public Guid Id { get; set; }
    }
}