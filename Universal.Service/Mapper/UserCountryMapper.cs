namespace Universal.Service
{
    public class UserCountryMapper : AutoMapper.Profile
    {
        public UserCountryMapper()
        {
            CreateMap<Core.UserCountryRegisterDto, Core.UserCountry>().ReverseMap();
            CreateMap<Core.UserCountryUpdateDto, Core.UserCountry>().ReverseMap();
        }
    }
}