using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class OrderConfigurarion : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasIndex(o => o.Id).IsUnique();

            builder.HasOne(o => o.User)
                .WithMany(u=> u.OrderHistory)
                .HasForeignKey(o=> o.UserId)
                .IsRequired() 
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.items)
               .WithOne(io => io.order)
               .HasForeignKey(io => io.OrderId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

            builder.Property(o => o.DateOrder)
                .HasColumnType("date")
                .HasDefaultValue(DateTime.Now);

        }
    }
}
