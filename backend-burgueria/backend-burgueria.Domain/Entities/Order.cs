using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_burgueria.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Product>? Products { get; set; }

    }
}