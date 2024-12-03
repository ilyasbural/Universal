namespace Universal.DataAccess
{
    using Core;
    using Microsoft.EntityFrameworkCore;

    public partial class UniversalContext : DbContext
    {
        public UniversalContext() { }
        public UniversalContext(DbContextOptions<UniversalContext> options) : base(options) { }

        public virtual DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<Announce> Announces { get; set; }
        public virtual DbSet<AnnounceDetail> AnnounceDetails { get; set; }
        public virtual DbSet<AnnounceLog> AnnounceLogs { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyAbout> CompanyAbouts { get; set; }
        public virtual DbSet<CompanyDetail> CompanyDetails { get; set; }
        public virtual DbSet<CompanyFollower> CompanyFollowers { get; set; }
        public virtual DbSet<CompanySettings> CompanySettings { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Emoji> Emojis { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Management> Managements { get; set; }
        public virtual DbSet<ManagementContact> ManagementContacts { get; set; }
        public virtual DbSet<ManagementDetail> ManagementDetails { get; set; }
        public virtual DbSet<ManagementEmail> ManagementEmails { get; set; }
        public virtual DbSet<MessageBox> MessageBoxes { get; set; }
        public virtual DbSet<Network> Networks { get; set; }
        public virtual DbSet<NetworkAction> NetworkActions { get; set; }
        public virtual DbSet<NetworkComment> NetworkComents { get; set; }
        public virtual DbSet<NetworkDetail> NetworkDetails { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyDetail> SurveyDetails { get; set; }
        public virtual DbSet<SurveyHistory> SurveyHistories { get; set; }
        public virtual DbSet<SurveyLog> SurveyLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAbility> UserAbilities { get; set; }
        public virtual DbSet<UserAbout> UserAbouts { get; set; }
        public virtual DbSet<UserCertificate> UserCertificates { get; set; }
        public virtual DbSet<UserCountry> UserCountries { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserEducation> UserEducations { get; set; }
        public virtual DbSet<UserExperience> UserExperiences { get; set; }
        public virtual DbSet<UserFollower> UserFollowers { get; set; }
        public virtual DbSet<UserLanguage> UserLanguages { get; set; }
        public virtual DbSet<UserNetwork> UserNetworks { get; set; }
        public virtual DbSet<UserProject> UserProjects { get; set; }
        public virtual DbSet<UserPublish> UserPublishes { get; set; }
        public virtual DbSet<UserReferance> UserReferances { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<UserVideo> UserVideos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=NATILUS; Database=UNIVERSAL;  User Id = sa; Password = Fenerbahce2932; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AbilityMapping());
            modelBuilder.ApplyConfiguration(new AnnounceDetailMapping());
            modelBuilder.ApplyConfiguration(new AnnounceLogMapping());
            modelBuilder.ApplyConfiguration(new AnnounceMapping());
            modelBuilder.ApplyConfiguration(new CertificateMapping());
            modelBuilder.ApplyConfiguration(new CollegeMapping());
            modelBuilder.ApplyConfiguration(new CompanyAboutMapping());
            modelBuilder.ApplyConfiguration(new CompanyDetailMapping());
            modelBuilder.ApplyConfiguration(new CompanyFollowerMapping());
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new CompanySettingsMapping());
            modelBuilder.ApplyConfiguration(new CountryMapping());
            modelBuilder.ApplyConfiguration(new EmojiMapping());
            modelBuilder.ApplyConfiguration(new JobPostingApplyMapping());
            modelBuilder.ApplyConfiguration(new JobPostingDetailMapping());
            modelBuilder.ApplyConfiguration(new JobPostingMapping());
            modelBuilder.ApplyConfiguration(new LanguageMapping());
            modelBuilder.ApplyConfiguration(new ManagementContactMapping());
            modelBuilder.ApplyConfiguration(new ManagementDetailMapping());
            modelBuilder.ApplyConfiguration(new ManagementEmailMapping());
            modelBuilder.ApplyConfiguration(new ManagementMapping());
            modelBuilder.ApplyConfiguration(new MessageBoxMapping());
            modelBuilder.ApplyConfiguration(new NetworkActionMapping());
            modelBuilder.ApplyConfiguration(new NetworkCommentMapping());
            modelBuilder.ApplyConfiguration(new NetworkDetailMapping());
            modelBuilder.ApplyConfiguration(new NetworkMapping());
            modelBuilder.ApplyConfiguration(new OccupationMapping());
            modelBuilder.ApplyConfiguration(new PositionMapping());
            modelBuilder.ApplyConfiguration(new RegionMapping());
            modelBuilder.ApplyConfiguration(new SurveyDetailMapping());
            modelBuilder.ApplyConfiguration(new SurveyHistoryMapping());
            modelBuilder.ApplyConfiguration(new SurveyLogMapping());
            modelBuilder.ApplyConfiguration(new SurveyMapping());
            modelBuilder.ApplyConfiguration(new UserAbilityMapping());
            modelBuilder.ApplyConfiguration(new UserAboutMapping());
            modelBuilder.ApplyConfiguration(new UserCertificateMapping());
            modelBuilder.ApplyConfiguration(new UserCountryMapping());
            modelBuilder.ApplyConfiguration(new UserDetailMapping());
            modelBuilder.ApplyConfiguration(new UserEducationMapping());
            modelBuilder.ApplyConfiguration(new UserExperienceMapping());
            modelBuilder.ApplyConfiguration(new UserFollowerMapping());
            modelBuilder.ApplyConfiguration(new UserLanguageMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserNetworkMapping());
            modelBuilder.ApplyConfiguration(new UserProjectMapping());
            modelBuilder.ApplyConfiguration(new UserPublishMapping());
            modelBuilder.ApplyConfiguration(new UserReferanceMapping());
            modelBuilder.ApplyConfiguration(new UserSettingsMapping());
            modelBuilder.ApplyConfiguration(new UserTypeMapping());
            modelBuilder.ApplyConfiguration(new UserVideoMapping());
        }
    }
}