using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_burgueria.Models.Dto.Product
{
  public class UpdateProduct
  {
    [Key]
    [Column("id")]
    [Required(ErrorMessage = "É necessário um Id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [Column("ingredientid")]
    public int IngredientId { get; set; }

    [JsonIgnore]
    public virtual List<Ingredient> Ingredient { get; set; }
  }
}