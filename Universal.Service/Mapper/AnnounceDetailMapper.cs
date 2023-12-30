namespace Universal.Service
{
    public class AnnounceDetailMapper : AutoMapper.Profile
    {
        public AnnounceDetailMapper()
        {
            CreateMap<Core.AnnounceDetailRegisterDto, Core.AnnounceDetail>().ReverseMap();
            CreateMap<Core.AnnounceDetailUpdateDto, Core.AnnounceDetail>().ReverseMap();
        }
    }
}