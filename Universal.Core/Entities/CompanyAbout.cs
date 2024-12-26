namespace Universal.Core
{
    public class CompanyAbout : Base<CompanyAbout>, IEntity
    {
        public String Description { get; set; } = String.Empty;

        public CompanyAbout()
        {

        }
    }
}