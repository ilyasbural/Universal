namespace Universal.Service
{
    public class UserDetailMapper : AutoMapper.Profile
    {
        public UserDetailMapper()
        {
            CreateMap<Core.UserDetailRegisterDto, Core.UserDetail>().ReverseMap();
            CreateMap<Core.UserDetailUpdateDto, Core.UserDetail>().ReverseMap();
        }
    }
}