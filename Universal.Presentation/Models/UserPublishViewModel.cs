namespace Universal.Presentation
{
    public class UserPublishViewModel : BaseViewModel<UserPublishViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}