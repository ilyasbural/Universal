namespace Universal.Service
{
    public class UserFollowerMapper : AutoMapper.Profile
    {
        public UserFollowerMapper()
        {
            CreateMap<Core.UserFollowerRegisterDto, Core.UserFollower>().ReverseMap();
            CreateMap<Core.UserFollowerUpdateDto, Core.UserFollower>().ReverseMap();
        }
    }
}