namespace Universal.Service
{
    public class PositionMapper : AutoMapper.Profile
    {
        public PositionMapper()
        {
            CreateMap<Core.PositionRegisterDto, Core.Position>().ReverseMap();
            CreateMap<Core.PositionUpdateDto, Core.Position>().ReverseMap();
        }
    }
}