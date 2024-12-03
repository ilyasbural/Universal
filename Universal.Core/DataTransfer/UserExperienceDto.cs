namespace Universal.Core
{
    public class UserExperienceRegisterDto
    {
        public Guid UserId { get; set; }
    }

    public class UserExperienceUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserExperienceDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserExperienceSelectDto
    {
        public Guid Id { get; set; }
    }
}