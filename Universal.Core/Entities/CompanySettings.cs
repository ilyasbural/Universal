namespace Universal.Core
{
    public class CompanySettings : Base<CompanySettings>, IEntity
    {
        public Boolean AutomaticEmail { get; set; } = false;

        public CompanySettings()
        {

        }
    }
}