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


            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.OriginalPrice).IsRequired();

            builder.Property(x => x.ViewCount).IsRequired().HasDefaultValue(0);

            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Color).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoTitle).HasMaxLength(500);

            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}
