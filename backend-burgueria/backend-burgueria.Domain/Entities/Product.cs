using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_burgueria.Models
{
  [Table("product")]
  public class Product
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

    public int OrderId { get; set; }

    public virtual Order Orders { get; set; }

  }
}