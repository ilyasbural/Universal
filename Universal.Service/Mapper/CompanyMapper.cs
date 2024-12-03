namespace Universal.Service
{
    public class CompanyMapper : AutoMapper.Profile
    {
        public CompanyMapper()
        {
            CreateMap<Core.CompanyRegisterDto, Core.Company>().ReverseMap();
            CreateMap<Core.CompanyUpdateDto, Core.Company>().ReverseMap();
        }
    }
}