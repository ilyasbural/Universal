namespace Universal.Presentation
{
    public class UserAboutViewModel : BaseViewModel<UserAboutViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
        public string About { get; set; } = String.Empty;
    }
}