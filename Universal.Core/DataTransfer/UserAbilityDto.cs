namespace Universal.Core
{
    public class UserAbilityRegisterDto
    {
        public Guid UserId { get; set; }
        public Guid AbilityId { get; set; }
    }

    public class UserAbilityUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid AbilityId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserAbilityDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserAbilitySelectDto
    {
        public Guid Id { get; set; }
    }
}