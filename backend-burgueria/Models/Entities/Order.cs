using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_burgueria.Models
{
  [Table("order")]
  public class Order
  {
    [Key]
    public int Id { get; set; }

    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual List<Product> Products { get; set; }

  }
}