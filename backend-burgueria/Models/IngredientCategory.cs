using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_burgueria.Models
{
  [Table("category")]
  public class IngredientCategory
  {
    [Key]
    public int Id {get; set;}

    public string CategoryName {get; set;}

    [JsonIgnore]
    public virtual List<Ingredient> Ingredient {get; set;}
  }
}