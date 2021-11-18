using EasyOrder.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        //Install-package Microsoft.EntityFrameworkCore.Relational
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Table)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder
                .Property(o => o.Number)
                .IsRequired()
                .HasDefaultValueSql("NEXT VALUE FOR NumberOrder");

            //builder.Property(x => x.Number) //Incremental
            //    .IsRequired()
            //    .ValueGeneratedOnAdd();

            // 1 : N => Order : Items
            builder.HasMany(f => f.Items)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.IdOrder);

            builder.ToTable("Orders");
        }
    }
}
