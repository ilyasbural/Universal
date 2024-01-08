namespace Universal.Presentation
{
    public class UserViewModel : BaseViewModel<UserViewModel>
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}