using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_burgueria.Models
{
  [Table("order")]
  public class Order
  {
    [Key]
    public int Id {get; set;}


  }
}