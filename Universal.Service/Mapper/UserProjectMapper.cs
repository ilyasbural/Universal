namespace Universal.Service
{
    public class UserProjectMapper : AutoMapper.Profile
    {
        public UserProjectMapper()
        {
            CreateMap<Core.UserProjectRegisterDto, Core.UserProject>().ReverseMap();
            CreateMap<Core.UserProjectUpdateDto, Core.UserProject>().ReverseMap();
        }
    }
}