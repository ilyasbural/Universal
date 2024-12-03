namespace Universal.Core
{
    public class SurveyHistory : Base<SurveyHistory>, IEntity
    {
        public Survey Survey { get; set; } = null!;

        public SurveyHistory()
        {

        }
    }
}