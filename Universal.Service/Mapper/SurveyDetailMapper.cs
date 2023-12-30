namespace Universal.Service
{
    public class SurveyDetailMapper : AutoMapper.Profile
    {
        public SurveyDetailMapper()
        {
            CreateMap<Core.SurveyDetailRegisterDto, Core.SurveyDetail>().ReverseMap();
            CreateMap<Core.SurveyDetailUpdateDto, Core.SurveyDetail>().ReverseMap();
        }
    }
}