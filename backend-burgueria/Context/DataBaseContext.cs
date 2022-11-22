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
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientCategory> IngredientCategories { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder Builder)
    {
      Builder.Entity<Product>()
      .HasOne(product => product.Ingredient)
      .WithMany(ingredient => ingredient.Product)
      .HasForeignKey(product => product.IngredientId);
    }

  }
}