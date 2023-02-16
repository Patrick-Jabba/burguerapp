using backend_burgueria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_burgueria.Infra.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).HasColumnType("varchar(300)");
        }
    }
}
