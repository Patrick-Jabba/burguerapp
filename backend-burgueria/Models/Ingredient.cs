using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_burgueria.Models
{
  [Table("ingredient")]
  public class Ingredient
  {
    [Key]
    public int Id { get; set; }

    [JsonIgnore]
    public string Name { get; set; }

    [JsonIgnore]
    public int IdCategory { get; set; }

    // public virtual Product Product { get; set; }

    public virtual List<Product> Products {get; set;}

    public int ProductId {get; set;}

    [JsonIgnore]
    public IngredientCategory IngredientCategory { get; set; }

  }
}