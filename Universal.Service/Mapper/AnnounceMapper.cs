namespace Universal.Service
{
    public class AnnounceMapper : AutoMapper.Profile
    {
        public AnnounceMapper()
        {
            CreateMap<Core.AnnounceRegisterDto, Core.Announce>().ReverseMap();
            CreateMap<Core.AnnounceUpdateDto, Core.Announce>().ReverseMap();
        }
    }
}