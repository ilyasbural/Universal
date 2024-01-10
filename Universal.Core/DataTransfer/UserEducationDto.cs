namespace Universal.Core
{
    public class UserEducationRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserEducationUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserEducationDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserEducationSelectDto
    {
        public Guid Id { get; set; }
    }
}