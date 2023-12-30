namespace Universal.Service
{
    public class UserTypeMapper : AutoMapper.Profile
    {
        public UserTypeMapper()
        {
            CreateMap<Core.UserTypeRegisterDto, Core.UserType>().ReverseMap();
            CreateMap<Core.UserTypeUpdateDto, Core.UserType>().ReverseMap();
        }
    }
}