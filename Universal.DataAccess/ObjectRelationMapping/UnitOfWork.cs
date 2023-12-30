namespace Universal.DataAccess
{
    using Core;

    public class UnitOfWork : IUnitOfWork
    {
        public IAbility Ability => AbilityRepository ?? new AbilityRepositoryEF(DbContext);
        public IAnnounce Announce => AnnounceRepository ?? new AnnounceRepositoryEF(DbContext);
        public IAnnounceDetail AnnounceDetail => AnnounceDetailRepository ?? new AnnounceDetailRepositoryEF(DbContext);
        public IAnnounceLog AnnounceLog => AnnounceLogRepository ?? new AnnounceLogRepositoryEF(DbContext);
        public ICertificate Certificate => CertificateRepository ?? new CertificateRepositoryEF(DbContext);
        public ICollege College => CollegeRepository ?? new CollegeRepositoryEF(DbContext);
        public ICompany Company => CompanyRepository ?? new CompanyRepositoryEF(DbContext);
        public ICompanyAbout CompanyAbout => CompanyAboutRepository ?? new CompanyAboutRepositoryEF(DbContext);
        public ICompanyDetail CompanyDetail => CompanyDetailRepository ?? new CompanyDetailRepositoryEF(DbContext);
        public ICompanyFollower CompanyFollower => CompanyFollowerRepository ?? new CompanyFollowerRepositoryEF(DbContext);
        public ICompanySettings CompanySettings => CompanySettingsRepository ?? new CompanySettingsRepositoryEF(DbContext);
        public ICountry Country => CountryRepository ?? new CountryRepositoryEF(DbContext);
        public IEmoji Emoji => EmojiRepository ?? new EmojiRepositoryEF(DbContext);
        public IJobPosting JobPosting => JobPostingRepository ?? new JobPostingRepositoryEF(DbContext);
        public IJobPostingDetail JobPostingDetail => JobPostingDetailRepository = new JobPostingDetailRepositoryEF(DbContext);
        public IJobPostingApply JobPostingApply => JobPostingApplyRepository = new JobPostingApplyRepositoryEF(DbContext);
        public ILanguage Language => LanguageRepository ?? new LanguageRepositoryEF(DbContext);
        public IManagement Management => ManagementRepository ?? new ManagementRepositoryEF(DbContext);
        public IManagementContact ManagementContact => ManagementContactRepository ?? new ManagementContactRepositoryEF(DbContext);
        public IManagementDetail ManagementDetail => ManagementDetailRepository ?? new ManagementDetailRepositoryEF(DbContext);
        public IManagementEmail ManagementEmail => ManagementEmailRepository ?? new ManagementEmailRepositoryEF(DbContext);
        public IMessageBox MessageBox => MessageBoxRepository ?? new MessageBoxRepositoryEF(DbContext);
        public INetwork Network => NetworkRepository ?? new NetworkRepositoryEF(DbContext);
        public INetworkAction NetworkAction => NetworkActionRepository ?? new NetworkActionRepositoryEF(DbContext);
        public INetworkComment NetworkComment => NetworkCommentRepository ?? new NetworkCommentRepositoryEF(DbContext);
        public INetworkDetail NetworkDetail => NetworkDetailRepository ?? new NetworkDetailRepositoryEF(DbContext);
        public IOccupation Occupation => OccupationRepository ?? new OccupationRepositoryEF(DbContext);
        public IPosition Position => PositionRepository ?? new PositionRepositoryEF(DbContext);
        public IRegion Region => RegionRepository ?? new RegionRepositoryEF(DbContext);
        public ISurvey Survey => SurveyRepository ?? new SurveyRepositoryEF(DbContext);
        public ISurveyDetail SurveyDetail => SurveyDetailRepository ?? new SurveyDetailRepositoryEF(DbContext);
        public ISurveyHistory SurveyHistory => SurveyHistoryRepository ?? new SurveyHistoryRepositoryEF(DbContext);
        public ISurveyLog SurveyLog => SurveyLogRepository ?? new SurveyLogRepositoryEF(DbContext);
        public IUser User => UserRepository ?? new UserRepositoryEF(DbContext);
        public IUserAbility UserAbility => UserAbilityRepository ?? new UserAbilityRepositoryEF(DbContext);
        public IUserAbout UserAbout => UserAboutRepository ?? new UserAboutRepositoryEF(DbContext);
        public IUserCertificate UserCertificate => UserCertificateRepository ?? new UserCertificateRepositoryEF(DbContext);
        public IUserCountry UserCountry => UserCountryRepository ?? new UserCountryRepositoryEF(DbContext);
        public IUserDetail UserDetail => UserDetailRepository ?? new UserDetailRepositoryEF(DbContext);
        public IUserEducation UserEducation => UserEducationRepository ?? new UserEducationRepositoryEF(DbContext);
        public IUserExperience UserExperience => UserExperienceRepository ?? new UserExperienceRepositoryEF(DbContext);
        public IUserFollower UserFollower => UserFollowerRepository ?? new UserFollowerRepositoryEF(DbContext);
        public IUserLanguage UserLanguage => UserLanguageRepository ?? new UserLanguageRepositoryEF(DbContext);
        public IUserNetwork UserNetwork => UserNetworkRepository ?? new UserNetworkRepositoryEF(DbContext);
        public IUserProject UserProject => UserProjectRepository ?? new UserProjectRepositoryEF(DbContext);
        public IUserPublish UserPublish => UserPublishRepository ?? new UserPublishRepositoryEF(DbContext);
        public IUserReferance UserReferance => UserReferanceRepository ?? new UserReferanceRepositoryEF(DbContext);
        public IUserSettings UserSettings => UserSettingsRepository ?? new UserSettingsRepositoryEF(DbContext);
        public IUserType UserType => UserTypeRepository ?? new UserTypeRepositoryEF(DbContext);
        public IUserVideo UserVideo => UserVideoRepository ?? new UserVideoRepositoryEF(DbContext);

        UniversalContext DbContext;

        public UnitOfWork(UniversalContext dbContext)
        {
            DbContext = dbContext;
        }

        protected AbilityRepositoryEF AbilityRepository { get; set; } = null!;
        protected AnnounceRepositoryEF AnnounceRepository { get; set; } = null!;
        protected AnnounceDetailRepositoryEF AnnounceDetailRepository { get; set; } = null!;
        protected AnnounceLogRepositoryEF AnnounceLogRepository { get; set; } = null!;
        protected CertificateRepositoryEF CertificateRepository { get; set; } = null!;
        protected CollegeRepositoryEF CollegeRepository { get; set; } = null!;
        protected CompanyAboutRepositoryEF CompanyAboutRepository { get; set; } = null!;
        protected CompanyRepositoryEF CompanyRepository { get; set; } = null!;
        protected CompanyDetailRepositoryEF CompanyDetailRepository { get; set; } = null!;
        protected CompanyFollowerRepositoryEF CompanyFollowerRepository { get; set; } = null!;
        protected CompanySettingsRepositoryEF CompanySettingsRepository { get; set; } = null!;
        protected CountryRepositoryEF CountryRepository { get; set; } = null!;
        protected EmojiRepositoryEF EmojiRepository { get; set; } = null!;
        protected JobPostingApplyRepositoryEF JobPostingApplyRepository { get; set; } = null!;
        protected JobPostingRepositoryEF JobPostingRepository { get; set; } = null!;
        protected JobPostingDetailRepositoryEF JobPostingDetailRepository { get; set; } = null!;
        protected LanguageRepositoryEF LanguageRepository { get; set; } = null!;
        protected ManagementRepositoryEF ManagementRepository { get; set; } = null!;
        protected ManagementDetailRepositoryEF ManagementDetailRepository { get; set; } = null!;
        protected ManagementContactRepositoryEF ManagementContactRepository { get; set; } = null!;
        protected ManagementEmailRepositoryEF ManagementEmailRepository { get; set; } = null!;
        protected MessageBoxRepositoryEF MessageBoxRepository { get; set; } = null!;
        protected NetworkActionRepositoryEF NetworkActionRepository { get; set; } = null!;
        protected NetworkCommentRepositoryEF NetworkCommentRepository { get; set; } = null!;
        protected NetworkRepositoryEF NetworkRepository { get; set; } = null!;
        protected NetworkDetailRepositoryEF NetworkDetailRepository { get; set; } = null!;
        protected OccupationRepositoryEF OccupationRepository { get; set; } = null!;
        protected PositionRepositoryEF PositionRepository { get; set; } = null!;
        protected RegionRepositoryEF RegionRepository { get; set; } = null!;
        protected SurveyRepositoryEF SurveyRepository { get; set; } = null!;
        protected SurveyDetailRepositoryEF SurveyDetailRepository { get; set; } = null!;
        protected SurveyHistoryRepositoryEF SurveyHistoryRepository { get; set; } = null!;
        protected SurveyLogRepositoryEF SurveyLogRepository { get; set; } = null!;
        protected UserAbilityRepositoryEF UserAbilityRepository { get; set; } = null!;
        protected UserAboutRepositoryEF UserAboutRepository { get; set; } = null!;
        protected UserCertificateRepositoryEF UserCertificateRepository { get; set; } = null!;
        protected UserRepositoryEF UserRepository { get; set; } = null!;
        protected UserCountryRepositoryEF UserCountryRepository { get; set; } = null!;
        protected UserDetailRepositoryEF UserDetailRepository { get; set; } = null!;
        protected UserEducationRepositoryEF UserEducationRepository { get; set; } = null!;
        protected UserExperienceRepositoryEF UserExperienceRepository { get; set; } = null!;
        protected UserFollowerRepositoryEF UserFollowerRepository { get; set; } = null!;
        protected UserLanguageRepositoryEF UserLanguageRepository { get; set; } = null!;
        protected UserNetworkRepositoryEF UserNetworkRepository { get; set; } = null!;
        protected UserProjectRepositoryEF UserProjectRepository { get; set; } = null!;
        protected UserPublishRepositoryEF UserPublishRepository { get; set; } = null!;
        protected UserReferanceRepositoryEF UserReferanceRepository { get; set; } = null!;
        protected UserSettingsRepositoryEF UserSettingsRepository { get; set; } = null!;
        protected UserTypeRepositoryEF UserTypeRepository { get; set; } = null!;
        protected UserVideoRepositoryEF UserVideoRepository { get; set; } = null!;

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await DbContext.DisposeAsync();
        }
    }
}