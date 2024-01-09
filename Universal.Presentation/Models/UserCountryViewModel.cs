namespace Universal.Presentation
{
    public class UserCountryViewModel : BaseViewModel<UserCountryViewModel>
    {
        public UserViewModel User { get; set; } = new UserViewModel();
        public CountryViewModel Country { get; set; } = new CountryViewModel();
    }
}