namespace Universal.Service
{
    public class UserPublishMapper : AutoMapper.Profile
    {
        public UserPublishMapper()
        {
            CreateMap<Core.UserPublishRegisterDto, Core.UserPublish>().ReverseMap();
            CreateMap<Core.UserPublishUpdateDto, Core.UserPublish>().ReverseMap();
        }
    }
}