namespace Universal.Service
{
    public class NetworkMapper : AutoMapper.Profile
    {
        public NetworkMapper()
        {
            CreateMap<Core.NetworkRegisterDto, Core.Network>().ReverseMap();
            CreateMap<Core.NetworkUpdateDto, Core.Network>().ReverseMap();
        }
    }
}