using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data.Entities;

namespace App.Data.Configurations
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("ProductDetails");

            builder.HasKey(x => x.ProductId);
            builder.HasOne(c => c.Product).WithOne(c => c.ProductDetail).HasForeignKey<ProductDetail>(c => c.ProductId);
            builder.HasOne(c => c.Unit).WithMany(c => c.ProductDetails).HasForeignKey(c => c.UnitId);
            builder.HasOne(c => c.Manufacturer).WithMany(c => c.ProductDetails).HasForeignKey(c => c.ManufacturerId);
        }
    }
}
