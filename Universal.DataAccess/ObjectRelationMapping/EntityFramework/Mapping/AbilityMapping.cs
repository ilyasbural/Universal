namespace Universal.DataAccess
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AbilityMapping : IEntityTypeConfiguration<Ability>
    {
        public void Configure(EntityTypeBuilder<Ability> builder)
        {
            builder.Property(e => e.Id);
            builder.Property(e => e.Name).HasColumnType("NVARCHAR").HasMaxLength(100);
            builder.Property(x => x.RegisterDate).HasColumnType("DATETIME");
            builder.Property(x => x.UpdateDate).HasColumnType("DATETIME");
            builder.Property(e => e.IsActive);
            builder.ToTable("Ability");
        }
    }
}