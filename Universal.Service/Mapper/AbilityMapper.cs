namespace Universal.Service
{
    public class AbilityMapper : AutoMapper.Profile
    {
        public AbilityMapper()
        {
            CreateMap<Core.AbilityRegisterDto, Core.Ability>().ReverseMap();
            CreateMap<Core.AbilityUpdateDto, Core.Ability>().ReverseMap();
        }
    }
}