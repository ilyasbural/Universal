namespace Universal.Service
{
    public class ManagementEmailMapper : AutoMapper.Profile
    {
        public ManagementEmailMapper()
        {
            CreateMap<Core.ManagementEmailRegisterDto, Core.ManagementEmail>().ReverseMap();
            CreateMap<Core.ManagementEmailUpdateDto, Core.ManagementEmail>().ReverseMap();
        }
    }
}