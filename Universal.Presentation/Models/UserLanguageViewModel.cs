namespace Universal.Presentation
{
    public class UserLanguageViewModel : BaseViewModel<UserLanguageViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
        public LanguageViewModel Language { get; set; } = new LanguageViewModel();
    }
}