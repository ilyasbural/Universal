namespace Universal.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAbility Ability { get; }
        IAnnounce Announce { get; }
        IAnnounceDetail AnnounceDetail { get; }
        IAnnounceLog AnnounceLog { get; }
        ICertificate Certificate { get; }
        ICollege College { get; }
        ICompanyAbout CompanyAbout { get; }
        ICompanyDetail CompanyDetail { get; }
        ICompanyFollower CompanyFollower { get; }
        ICompany Company { get; }
        ICompanySettings CompanySettings { get; }
        ICountry Country { get; }
        IEmoji Emoji { get; }
        IJobPostingApply JobPostingApply { get; }
        IJobPostingDetail JobPostingDetail { get; }
        IJobPosting JobPosting { get; }
        ILanguage Language { get; }
        IManagement Management { get; }
        IManagementContact ManagementContact { get; }
        IManagementDetail ManagementDetail { get; }
        IManagementEmail ManagementEmail { get; }
        IMessageBox MessageBox { get; }
        INetworkAction NetworkAction { get; }
        INetworkComment NetworkComment { get; }
        INetworkDetail NetworkDetail { get; }
        INetwork Network { get; }
        IOccupation Occupation { get; }
        IPosition Position { get; }
        IRegion Region { get; }
        ISurvey Survey { get; }
        ISurveyDetail SurveyDetail { get; }
        ISurveyHistory SurveyHistory { get; }
        ISurveyLog SurveyLog { get; }
        IUserAbility UserAbility { get; }
        IUserAbout UserAbout { get; }
        IUserCertificate UserCertificate { get; }
        IUserCountry UserCountry { get; }
        IUserDetail UserDetail { get; }
        IUserEducation UserEducation { get; }
        IUserExperience UserExperience { get; }
        IUserFollower UserFollower { get; }
        IUserLanguage UserLanguage { get; }
        IUserNetwork UserNetwork { get; }
        IUserProject UserProject { get; }
        IUserPublish UserPublish { get; }
        IUserReferance UserReferance { get; }
        IUser User { get; }
        IUserSettings UserSettings { get; }
        IUserType UserType { get; }
        IUserVideo UserVideo { get; }
        Task<int> SaveChangesAsync();
    }
}