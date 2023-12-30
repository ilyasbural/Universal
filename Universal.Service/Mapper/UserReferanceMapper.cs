namespace Universal.Service
{
    public class UserReferanceMapper : AutoMapper.Profile
    {
        public UserReferanceMapper()
        {
            CreateMap<Core.UserReferanceRegisterDto, Core.UserReferance>().ReverseMap();
            CreateMap<Core.UserReferanceUpdateDto, Core.UserReferance>().ReverseMap();
        }
    }
}