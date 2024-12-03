namespace Universal.Service
{
    public class CompanyDetailMapper : AutoMapper.Profile
    {
        public CompanyDetailMapper()
        {
            CreateMap<Core.CompanyDetailRegisterDto, Core.CompanyDetail>().ReverseMap();
            CreateMap<Core.CompanyDetailUpdateDto, Core.CompanyDetail>().ReverseMap();
        }
    }
}