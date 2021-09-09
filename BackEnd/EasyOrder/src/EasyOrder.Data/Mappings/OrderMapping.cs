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

            builder.Property(x => x.Number) //Incremental
                .IsRequired()
                .ValueGeneratedOnAdd();

           // moddelBuilder.HasSequence<int>("Order").StartsAt(100).IncrementsBy(1);
           // builder.Property(o => o.Number).HasDefaultValueSql("NEXT VALUE FOR Number");
         

            // 1 : N => Order : Items
            builder.HasMany(f => f.Items)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.IdOrder);

            builder.ToTable("Orders");
        }
    }
}
