namespace Universal.Core
{
    public class MessageBoxRegisterDto
    {

    }

    public class MessageBoxUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class MessageBoxDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class MessageBoxSelectDto
    {
        public Guid Id { get; set; }
    }
}