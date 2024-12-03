namespace Universal.Service
{
    public class UserExperienceMapper : AutoMapper.Profile
    {
        public UserExperienceMapper()
        {
            CreateMap<Core.UserExperienceRegisterDto, Core.UserExperience>().ReverseMap();
            CreateMap<Core.UserExperienceUpdateDto, Core.UserExperience>().ReverseMap();
        }
    }
}