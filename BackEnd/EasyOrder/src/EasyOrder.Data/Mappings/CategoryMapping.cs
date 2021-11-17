using EasyOrder.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        //Install-package Microsoft.EntityFrameworkCore.Relational
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Active)
                .IsRequired();

            // N : N => Categories : Extras
            //builder
            //    .HasMany(p => p.Extras)
            //    .WithMany(p => p.Categories)
            //    .UsingEntity(j => j.ToTable("CategoriesExtras"));

            builder.ToTable("Categories");
        }
    }
}
