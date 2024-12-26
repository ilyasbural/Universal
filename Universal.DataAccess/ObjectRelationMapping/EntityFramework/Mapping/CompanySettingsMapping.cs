namespace Universal.DataAccess
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CompanySettingsMapping : IEntityTypeConfiguration<CompanySettings>
    {
        public void Configure(EntityTypeBuilder<CompanySettings> builder)
        {
            builder.Property(e => e.Id);
            builder.Property(e => e.AutomaticEmail).HasColumnType("BIT");
			builder.Property(x => x.RegisterDate).HasColumnType("DATETIME");
            builder.Property(x => x.UpdateDate).HasColumnType("DATETIME");
            builder.Property(e => e.IsActive);
            builder.ToTable("CompanySettings");
        }
    }
}