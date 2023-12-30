namespace Universal.Service
{
    public class UserEducationMapper : AutoMapper.Profile
    {
        public UserEducationMapper()
        {
            CreateMap<Core.UserEducationRegisterDto, Core.UserEducation>().ReverseMap();
            CreateMap<Core.UserEducationUpdateDto, Core.UserEducation>().ReverseMap();
        }
    }
}