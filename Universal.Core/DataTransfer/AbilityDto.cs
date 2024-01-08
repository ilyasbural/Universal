namespace Universal.Core
{
    public class AbilityRegisterDto
    {
        public string Name { get; set; } = String.Empty;
    }

    public class AbilityUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }

    public class AbilityDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class AbilitySelectDto
    {
        public Guid Id { get; set; }
    }
}