namespace Universal.Core
{
    public class CompanyFollower : Base<CompanyFollower>, IEntity
    {
        public String Name { get; set; } = String.Empty;
        public String Lastname { get; set; } = String.Empty;

		public CompanyFollower()
        {

        }
    }
}