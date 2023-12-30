namespace Universal.Service
{
    public class UserLanguageMapper : AutoMapper.Profile
    {
        public UserLanguageMapper()
        {
            CreateMap<Core.UserLanguageRegisterDto, Core.UserLanguage>().ReverseMap();
            CreateMap<Core.UserLanguageUpdateDto, Core.UserLanguage>().ReverseMap();
        }
    }
}