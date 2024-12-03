namespace Universal.Service
{
    public class UserVideoMapper : AutoMapper.Profile
    {
        public UserVideoMapper()
        {
            CreateMap<Core.UserVideoRegisterDto, Core.UserVideo>().ReverseMap();
            CreateMap<Core.UserVideoUpdateDto, Core.UserVideo>().ReverseMap();
        }
    }
}