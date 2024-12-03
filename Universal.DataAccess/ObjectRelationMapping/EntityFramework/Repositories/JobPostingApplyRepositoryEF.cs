namespace Universal.DataAccess
{
    public class JobPostingApplyRepositoryEF : RepositoryBase<Core.JobPostingApply>, Core.IJobPostingApply
    {
        public JobPostingApplyRepositoryEF(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {

        }
    }
}