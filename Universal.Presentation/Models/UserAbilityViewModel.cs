namespace Universal.Presentation
{
    public class UserAbilityViewModel : BaseViewModel<UserAbilityViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
        public AbilityViewModel Ability { get; set; } = new AbilityViewModel();
    }
}