﻿using AdidasModels.Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdidasModels.Solution.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.Price).IsRequired(true);

            builder.Property(x => x.OriginalPrice).IsRequired(true);

            builder.Property(x => x.ViewCount).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.ProductName).IsRequired(true).HasMaxLength(200);

            builder.Property(x => x.Color).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoTitle).HasMaxLength(500);

            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);

            builder.Property(x => x.SeoTitle).IsRequired(false);

            builder.Property(x => x.Material).IsRequired(false);

            builder.Property(x => x.shoelace).IsRequired(false);

            builder.Property(x => x.DeGiay).IsRequired(false);

            builder.Property(x => x.KieuDang).IsRequired(false);
        }
    }
}
