namespace Universal.Presentation
{
    public class UserFollowerViewModel : BaseViewModel<UserFollowerViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}