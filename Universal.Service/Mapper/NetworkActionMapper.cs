namespace Universal.Service
{
    public class NetworkActionMapper : AutoMapper.Profile
    {
        public NetworkActionMapper()
        {
            CreateMap<Core.NetworkActionRegisterDto, Core.NetworkAction>().ReverseMap();
            CreateMap<Core.NetworkActionUpdateDto, Core.NetworkAction>().ReverseMap();
        }
    }
}