namespace Universal.Core
{
    public class RegionRegisterDto
    {

    }

    public class RegionUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class RegionDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class RegionSelectDto
    {
        public Guid Id { get; set; }
    }
}