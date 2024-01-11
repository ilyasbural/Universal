namespace Universal.Core
{
    public class SurveyDetail : Base<SurveyDetail>, IEntity
    {
        public Survey Survey { get; set; } = null!;

        public SurveyDetail()
        {

        }
    }
}