namespace Universal.Service
{
    public class CompanyAboutMapper : AutoMapper.Profile
    {
        public CompanyAboutMapper()
        {
            CreateMap<Core.CompanyAboutRegisterDto, Core.CompanyAbout>().ReverseMap();
            CreateMap<Core.CompanyAboutUpdateDto, Core.CompanyAbout>().ReverseMap();
        }
    }
}