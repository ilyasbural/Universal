namespace Universal.Presentation
{
    public class UserExperienceViewModel : BaseViewModel<UserExperienceViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}