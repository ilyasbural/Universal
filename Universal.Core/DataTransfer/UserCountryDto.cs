namespace Universal.Core
{
    public class UserCountryRegisterDto
    {
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
    }

    public class UserCountryUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
        public Guid Id { get; set; }
    }

    public class UserCountryDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class UserCountrySelectDto
    {
        public Guid Id { get; set; }
    }
}