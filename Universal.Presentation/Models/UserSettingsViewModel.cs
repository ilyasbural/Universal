namespace Universal.Presentation
{
    public class UserSettingsViewModel : BaseViewModel<UserSettingsViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}