namespace Universal.Service
{
    public class CompanySettingsMapper : AutoMapper.Profile
    {
        public CompanySettingsMapper()
        {
            CreateMap<Core.CompanySettingsRegisterDto, Core.CompanySettings>().ReverseMap();
            CreateMap<Core.CompanySettingsUpdateDto, Core.CompanySettings>().ReverseMap();
        }
    }
}