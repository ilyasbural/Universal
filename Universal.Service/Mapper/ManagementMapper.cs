namespace Universal.Service
{
    public class ManagementMapper : AutoMapper.Profile
    {
        public ManagementMapper()
        {
            CreateMap<Core.ManagementRegisterDto, Core.Management>().ReverseMap();
            CreateMap<Core.ManagementUpdateDto, Core.Management>().ReverseMap();
        }
    }
}