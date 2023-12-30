namespace Universal.Service
{
    public class JobPostingDetailMapper : AutoMapper.Profile
    {
        public JobPostingDetailMapper()
        {
            CreateMap<Core.JobPostingDetailRegisterDto, Core.JobPostingDetail>().ReverseMap();
            CreateMap<Core.JobPostingDetailUpdateDto, Core.JobPostingDetail>().ReverseMap();
        }
    }
}