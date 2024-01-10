namespace Universal.Presentation
{
    public class UserNetworkViewModel : BaseViewModel<UserNetworkViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}