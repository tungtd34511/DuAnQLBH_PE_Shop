using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data.Entities;

namespace App.Data.Configurations
{
    public class ProductInOderConfiguration : IEntityTypeConfiguration<ProductInOrder>
    {
        public void Configure(EntityTypeBuilder<ProductInOrder> builder)
        {
            builder.ToTable("ProductInOrders");

            builder.HasKey(x => new { x.OrderId, x.ProductVariationId });

            builder.HasOne(x => x.Order).WithMany(x => x.ProductInOrders).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.ProductVariation).WithMany(x => x.ProductInOrders).HasForeignKey(x => x.ProductVariationId);
        }
    }
}
