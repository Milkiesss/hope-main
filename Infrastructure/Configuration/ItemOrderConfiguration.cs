using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configuration
{
    public class ItemOrderConfiguration : IEntityTypeConfiguration<ItemOrder>
    {
        public void Configure(EntityTypeBuilder<ItemOrder> builder)
        {
            builder.HasKey(io => new { io.OrderId, io.ProductId });

            builder.HasOne(io => io.order)
                .WithMany(c => c.items)// У одного чека может быть много позиций заказа
                .HasForeignKey(io => io.OrderId)
                .IsRequired();

            builder.HasOne(io => io.Product)
                .WithMany()
                .HasForeignKey(io => io.ProductId)
                .IsRequired();

            builder.Property(io => io.Price)
                .HasColumnType("double precision")
                .IsRequired();

            builder.Property(io => io.Quantity).IsRequired();
        }
    }
}
