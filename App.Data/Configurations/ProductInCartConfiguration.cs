using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Configurations
{
    public class ProductInCartConfiguration : IEntityTypeConfiguration<ProductInCart>
    {
        public void Configure(EntityTypeBuilder<ProductInCart> builder)
        {
            builder.ToTable("ProductInCarts");

            builder.HasKey(x => new {x.ProductVariationId, x.CartId});

            builder.HasOne(x => x.Cart).WithMany(x => x.ProductInCarts).HasForeignKey(x => x.CartId);

            builder.HasOne(x => x.ProductVariation).WithMany(x => x.ProductInCarts).HasForeignKey(x => x.ProductVariationId);

        }
    }
}
