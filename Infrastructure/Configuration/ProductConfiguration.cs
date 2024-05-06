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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.UnitOfMeasure)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(p => p.Available);
            builder.Property(p => p.ExpiryDate)
                .HasColumnType("date");
            builder.Property(p => p.Price)
                .HasColumnType("double precision")
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Supplier)
                .WithMany()
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
