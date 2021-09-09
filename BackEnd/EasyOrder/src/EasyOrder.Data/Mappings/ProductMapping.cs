using EasyOrder.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        //Install-package Microsoft.EntityFrameworkCore.Relational
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Description)
               .HasColumnType("varchar(1000)");

            builder.Property(x => x.Price)
               .IsRequired();

            builder.Property(x => x.IdCategory)
               .IsRequired();

            // 1 : N => Item : Product
            builder.HasMany(f => f.Items)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.IdProduct);

            builder.ToTable("Products");
        }
    }
}
