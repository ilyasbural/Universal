namespace Universal.Core
{
    public class OccupationRegisterDto
    {

    }

    public class OccupationUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class OccupationDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class OccupationSelectDto
    {
        public Guid Id { get; set; }
    }
}