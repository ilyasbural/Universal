namespace Universal.Service
{
    public class JobPostingMapper : AutoMapper.Profile
    {
        public JobPostingMapper()
        {
            CreateMap<Core.JobPostingRegisterDto, Core.JobPosting>().ReverseMap();
            CreateMap<Core.JobPostingUpdateDto, Core.JobPosting>().ReverseMap();
        }
    }
}