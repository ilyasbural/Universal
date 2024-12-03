namespace Universal.Service
{
    public class RegionMapper : AutoMapper.Profile
    {
        public RegionMapper()
        {
            CreateMap<Core.RegionRegisterDto, Core.Region>().ReverseMap();
            CreateMap<Core.RegionUpdateDto, Core.Region>().ReverseMap();
        }
    }
}