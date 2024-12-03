namespace Universal.Service
{
    public class NetworkDetailMapper : AutoMapper.Profile
    {
        public NetworkDetailMapper()
        {
            CreateMap<Core.NetworkDetailRegisterDto, Core.NetworkDetail>().ReverseMap();
            CreateMap<Core.NetworkDetailUpdateDto, Core.NetworkDetail>().ReverseMap();
        }
    }
}