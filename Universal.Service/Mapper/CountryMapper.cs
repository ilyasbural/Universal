namespace Universal.Service
{
    public class CountryMapper : AutoMapper.Profile
    {
        public CountryMapper()
        {
            CreateMap<Core.CountryRegisterDto, Core.Country>().ReverseMap();
            CreateMap<Core.CountryUpdateDto, Core.Country>().ReverseMap();
        }
    }
}