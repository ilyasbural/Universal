namespace Universal.Presentation
{
    public class UserTypeViewModel : BaseViewModel<UserTypeViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}