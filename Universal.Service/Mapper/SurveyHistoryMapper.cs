namespace Universal.Service
{
    public class SurveyHistoryMapper : AutoMapper.Profile
    {
        public SurveyHistoryMapper()
        {
            CreateMap<Core.SurveyHistoryRegisterDto, Core.SurveyHistory>().ReverseMap();
            CreateMap<Core.SurveyHistoryUpdateDto, Core.SurveyHistory>().ReverseMap();
        }
    }
}