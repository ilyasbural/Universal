namespace Universal.Core
{
    public class CompanyAbout : Base<CompanyAbout>, IEntity
    {
        public string Description { get; set; } = String.Empty;

        public CompanyAbout()
        {

        }
    }
}