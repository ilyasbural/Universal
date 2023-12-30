namespace Universal.Service
{
    public class UserMapper : AutoMapper.Profile
    {
        public UserMapper()
        {
            CreateMap<Core.UserRegisterDto, Core.User>().ReverseMap();
            CreateMap<Core.UserUpdateDto, Core.User>().ReverseMap();
        }
    }
}