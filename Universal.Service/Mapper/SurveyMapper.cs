namespace Universal.Service
{
    public class SurveyMapper : AutoMapper.Profile
    {
        public SurveyMapper()
        {
            CreateMap<Core.SurveyRegisterDto, Core.Survey>().ReverseMap();
            CreateMap<Core.SurveyUpdateDto, Core.Survey>().ReverseMap();
        }
    }
}