namespace Universal.Core
{
    public class CompanyDetail : Base<CompanyDetail>, IEntity
    {
        public String Description { get; set; } = String.Empty;

        public CompanyDetail()
        {

        }
    }
}