namespace Universal.Service
{
    public class AnnounceLogMapper : AutoMapper.Profile
    {
        public AnnounceLogMapper()
        {
            CreateMap<Core.AnnounceLogRegisterDto, Core.AnnounceLog>().ReverseMap();
            CreateMap<Core.AnnounceLogUpdateDto, Core.AnnounceLog>().ReverseMap();
        }
    }
}