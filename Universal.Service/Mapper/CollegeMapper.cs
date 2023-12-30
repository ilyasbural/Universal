namespace Universal.Service
{
    public class CollegeMapper : AutoMapper.Profile
    {
        public CollegeMapper()
        {
            CreateMap<Core.CollegeRegisterDto, Core.College>().ReverseMap();
            CreateMap<Core.CollegeUpdateDto, Core.College>().ReverseMap();
        }
    }
}