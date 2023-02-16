namespace backend_burgueria.Models.Dto.Product
{
  public class AddProductDto
  {
    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public int IngredientId { get; set; }

    // public virtual List<Ingredient> Ingredient { get; set; }
  }
}