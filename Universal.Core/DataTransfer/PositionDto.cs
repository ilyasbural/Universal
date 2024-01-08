namespace Universal.Core
{
    public class PositionRegisterDto
    {

    }

    public class PositionUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class PositionDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class PositionSelectDto
    {
        public Guid Id { get; set; }
    }
}