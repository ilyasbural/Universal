namespace Universal.Service
{
    public class UserNetworkMapper : AutoMapper.Profile
    {
        public UserNetworkMapper()
        {
            CreateMap<Core.UserNetworkRegisterDto, Core.UserNetwork>().ReverseMap();
            CreateMap<Core.UserNetworkUpdateDto, Core.UserNetwork>().ReverseMap();
        }
    }
}