using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sample.Ef6.Entities;

namespace Sample.Ef6.Data.EntityTypeConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AppUsers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasConversion<string>()
                .HasMaxLength(36);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            var addressPropertyBuilder = builder.OwnsOne(x => x.Address, address =>
            {
                address.ToTable("UserAddress");
                address.WithOwner().HasForeignKey(x => x.UserId);

                address.HasKey(x => x.UserId);

                address.Property(x => x.UserId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasConversion<string>()
                .HasMaxLength(36);

                address.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(100);

                address.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(1000);

                address.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(1000);

                address.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(1000);

                address.Property(x => x.Line1)
                .IsRequired(false)
                .HasMaxLength(1000);

                address.Property(x => x.Line2)
                .IsRequired(false)
                .HasMaxLength(1000);

                address.Property(x => x.ZipCode)
               .IsRequired(false)
               .HasMaxLength(100);

            });
               


            
        }
    }
}
