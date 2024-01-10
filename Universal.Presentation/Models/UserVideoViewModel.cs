namespace Universal.Presentation
{
    public class UserVideoViewModel : BaseViewModel<UserVideoViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}