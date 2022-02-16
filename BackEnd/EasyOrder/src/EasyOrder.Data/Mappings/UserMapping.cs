using EasyOrder.Business.Models;
using EasyOrder.Business.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyOrder.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            //Email pertence ao Usuário, mapeia apenas o Email e não a classe
            builder.OwnsOne(x => x.Email, tf =>
            {
                tf.Property(x => x.Address)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"varchar({Email.EmailMaxLength})");
            });

            builder.Property(x => x.Active)
               .IsRequired()
               .HasDefaultValue(true);

            builder.ToTable("Users");
        }
    }
}
