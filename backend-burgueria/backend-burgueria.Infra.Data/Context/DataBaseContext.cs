using Microsoft.EntityFrameworkCore;
using backend_burgueria.Models;

namespace backend_burgueria.Context
{
  public class DataBaseContext : DbContext
  {
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

      modelBuilder.Entity<Product>()
            .HasOne(product => product.Orders)
            .WithMany(espaco => espaco.Products)
            .HasForeignKey(product => product.OrderId);

      // var produto = modelBuilder.Entity<Product>();
      // produto.ToTable("tb_produto");
      // produto.HasKey(x => x.Id);
      // produto.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
      // produto.Property(x => x.Name).HasColumnName("product_name").HasColumnType("varchar(100)").IsRequired();
    }

  }
}