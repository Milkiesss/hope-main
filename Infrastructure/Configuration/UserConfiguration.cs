using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id).IsUnique();

            builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(u => u.FullName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(u => u.Salt)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                    .IsRequired();

            builder.Property(u => u.Address)
                .IsRequired()//обязательно к заполнению
                .HasMaxLength(100);

            builder.HasMany(u => u.OrderHistory)//много заказов
                .WithOne(o => o.User) //один пользователь 
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);//.gри удалении пользователя удаляются все его заказы
        }
    }
}
