namespace Universal.Core
{
    public class SurveyLog : Base<SurveyLog>, IEntity
    {
        public Survey Survey { get; set; } = null!;

        public SurveyLog()
        {

        }
    }
}