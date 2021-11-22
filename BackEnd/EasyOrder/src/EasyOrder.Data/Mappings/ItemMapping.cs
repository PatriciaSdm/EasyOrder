using EasyOrder.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.Observation)
                .HasColumnType("varchar(1000)");

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.IdOrder)
               .IsRequired();

            builder.Property(x => x.IdProduct)
              .IsRequired();

            builder
                .HasOne(tc => tc.Order)
                .WithMany(car => car.Items)
                .OnDelete(DeleteBehavior.Cascade);

            // N : N => Items : Extras
            //builder
            //    .HasMany(p => p.Extras)
            //    .WithMany(p => p.Items)
            //    .UsingEntity(j => j.ToTable("ItemsExtras"));

            // 1 : N => Item : Extra
            builder.HasMany(f => f.ItemExtras)
                .WithOne(p => p.Item)
                .HasForeignKey(p => p.IdItem);

            builder.ToTable("Items");
        }
    }
}
