using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data.Entities;

namespace App.Data.Configurations
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.ToTable("UserDetails");
            builder.HasKey(x => x.UserId);
            builder.HasOne(c => c.User).WithOne(c => c.UserDetail).HasForeignKey<UserDetail>(c => c.UserId);
        }
    }
}