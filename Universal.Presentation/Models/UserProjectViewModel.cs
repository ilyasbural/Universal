namespace Universal.Presentation
{
    public class UserProjectViewModel : BaseViewModel<UserProjectViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}