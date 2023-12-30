namespace Universal.Service
{
    public class SurveyLogMapper : AutoMapper.Profile
    {
        public SurveyLogMapper()
        {
            CreateMap<Core.SurveyLogRegisterDto, Core.SurveyLog>().ReverseMap();
            CreateMap<Core.SurveyLogUpdateDto, Core.SurveyLog>().ReverseMap();
        }
    }
}