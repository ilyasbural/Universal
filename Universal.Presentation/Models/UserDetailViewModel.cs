namespace Universal.Presentation
{
    public class UserDetailViewModel : BaseViewModel<UserDetailViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}