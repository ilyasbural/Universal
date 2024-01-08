namespace Universal.Core
{
    public class CompanyDetail : Base<CompanyDetail>, IEntity
    {
        public string Description { get; set; } = String.Empty;

        public CompanyDetail()
        {

        }
    }
}