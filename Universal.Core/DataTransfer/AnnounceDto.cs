namespace Universal.Core
{
    public class AnnounceRegisterDto
    {

    }

    public class AnnounceUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }

    public class AnnounceDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class AnnounceSelectDto
    {
        public Guid Id { get; set; }
    }
}