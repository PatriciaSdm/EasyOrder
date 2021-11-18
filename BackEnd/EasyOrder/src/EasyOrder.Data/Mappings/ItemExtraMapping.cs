﻿using EasyOrder.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyOrder.Data.Mappings
{
    public class ItemExtraMapping : IEntityTypeConfiguration<ItemExtra>
    {
        public void Configure(EntityTypeBuilder<ItemExtra> builder)
        {
            builder.HasKey("IdItem", "IdExtra");

            builder.Property(x => x.IdItem)
                .IsRequired();

            builder.Property(x => x.IdExtra)
               .IsRequired();
        }
    }
}
