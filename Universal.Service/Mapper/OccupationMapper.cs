namespace Universal.Service
{
    public class OccupationMapper : AutoMapper.Profile
    {
        public OccupationMapper()
        {
            CreateMap<Core.OccupationRegisterDto, Core.Occupation>().ReverseMap();
            CreateMap<Core.OccupationUpdateDto, Core.Occupation>().ReverseMap();
        }
    }
}