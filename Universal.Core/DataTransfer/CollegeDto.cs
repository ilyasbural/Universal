namespace Universal.Core
{
    public class CollegeRegisterDto
    {

    }

    public class CollegeUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }

    public class CollegeDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class CollegeSelectDto
    {
        public Guid Id { get; set; }
    }
}