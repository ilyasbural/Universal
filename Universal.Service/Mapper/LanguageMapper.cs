namespace Universal.Service
{
    public class LanguageMapper : AutoMapper.Profile
    {
        public LanguageMapper()
        {
            CreateMap<Core.LanguageRegisterDto, Core.Language>().ReverseMap();
            CreateMap<Core.LanguageUpdateDto, Core.Language>().ReverseMap();
        }
    }
}