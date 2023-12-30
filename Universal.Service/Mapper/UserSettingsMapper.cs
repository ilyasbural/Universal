namespace Universal.Service
{
    public class UserSettingsMapper : AutoMapper.Profile
    {
        public UserSettingsMapper()
        {
            CreateMap<Core.UserSettingsRegisterDto, Core.UserSettings>().ReverseMap();
            CreateMap<Core.UserSettingsUpdateDto, Core.UserSettings>().ReverseMap();
        }
    }
}