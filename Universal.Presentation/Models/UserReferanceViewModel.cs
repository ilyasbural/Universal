namespace Universal.Presentation
{
    public class UserReferanceViewModel : BaseViewModel<UserReferanceViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}