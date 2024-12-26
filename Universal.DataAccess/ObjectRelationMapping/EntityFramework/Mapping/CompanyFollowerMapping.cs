namespace Universal.DataAccess
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CompanyFollowerMapping : IEntityTypeConfiguration<CompanyFollower>
    {
        public void Configure(EntityTypeBuilder<CompanyFollower> builder)
        {
            builder.Property(e => e.Id);
			builder.Property(e => e.Name).HasColumnType("NVARCHAR").HasMaxLength(100);
			builder.Property(x => x.RegisterDate).HasColumnType("DATETIME");
            builder.Property(x => x.UpdateDate).HasColumnType("DATETIME");
            builder.Property(e => e.IsActive);
            builder.ToTable("CompanyFollower");
        }
    }
}