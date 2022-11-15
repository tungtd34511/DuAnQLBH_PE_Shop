using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data.Entities;

namespace App.Data.Configurations
{
    public class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.ToTable("OrderHistories");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Order).WithMany(c => c.OrderHistories).HasForeignKey(c => c.OderId);
        }
    }
}
