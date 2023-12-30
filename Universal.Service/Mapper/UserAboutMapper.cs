namespace Universal.Service
{
    public class UserAboutMapper : AutoMapper.Profile
    {
        public UserAboutMapper()
        {
            CreateMap<Core.UserAboutRegisterDto, Core.UserAbout>().ReverseMap();
            CreateMap<Core.UserAboutUpdateDto, Core.UserAbout>().ReverseMap();
        }
    }
}