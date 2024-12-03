namespace Universal.Service
{
    public class ManagementContactMapper : AutoMapper.Profile
    {
        public ManagementContactMapper()
        {
            CreateMap<Core.ManagementContactRegisterDto, Core.ManagementContact>().ReverseMap();
            CreateMap<Core.ManagementContactUpdateDto, Core.ManagementContact>().ReverseMap();
        }
    }
}