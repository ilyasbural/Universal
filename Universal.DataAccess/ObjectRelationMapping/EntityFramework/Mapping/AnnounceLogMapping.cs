﻿namespace Universal.DataAccess
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AnnounceLogMapping : IEntityTypeConfiguration<AnnounceLog>
    {
        public void Configure(EntityTypeBuilder<AnnounceLog> builder)
        {
            builder.Property(e => e.Id);
			builder.Property(e => e.Note).HasColumnType("NVARCHAR").HasMaxLength(100);
			builder.Property(x => x.RegisterDate).HasColumnType("DATETIME");
            builder.Property(x => x.UpdateDate).HasColumnType("DATETIME");
            builder.Property(e => e.IsActive);
            builder.ToTable("AnnounceLog");
        }
    }
}