using EasyOrder.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyOrder.Data.Mappings
{
    public class CategoryExtraMapping : IEntityTypeConfiguration<CategoryExtra>
    {
        public void Configure(EntityTypeBuilder<CategoryExtra> builder)
        {
            builder.HasKey("IdCategory", "IdExtra");

            builder.Property(x => x.IdCategory)
                .IsRequired();

            builder.Property(x => x.IdExtra)
               .IsRequired();
        }
    }
}
