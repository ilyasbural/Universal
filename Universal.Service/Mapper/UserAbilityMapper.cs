namespace Universal.Service
{
    public class UserAbilityMapper : AutoMapper.Profile
    {
        public UserAbilityMapper()
        {
            CreateMap<Core.UserAbilityRegisterDto, Core.UserAbility>().ReverseMap();
            CreateMap<Core.UserAbilityUpdateDto, Core.UserAbility>().ReverseMap();
        }
    }
}