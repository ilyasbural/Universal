namespace Universal.Service
{
    public class ManagementDetailMapper : AutoMapper.Profile
    {
        public ManagementDetailMapper()
        {
            CreateMap<Core.ManagementDetailRegisterDto, Core.ManagementDetail>().ReverseMap();
            CreateMap<Core.ManagementDetailUpdateDto, Core.ManagementDetail>().ReverseMap();
        }
    }
}