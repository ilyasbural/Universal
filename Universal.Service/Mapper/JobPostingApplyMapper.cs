namespace Universal.Service
{
    public class JobPostingApplyMapper : AutoMapper.Profile
    {
        public JobPostingApplyMapper()
        {
            CreateMap<Core.JobPostingApplyRegisterDto, Core.JobPostingApply>().ReverseMap();
            CreateMap<Core.JobPostingApplyUpdateDto, Core.JobPostingApply>().ReverseMap();
        }
    }
}