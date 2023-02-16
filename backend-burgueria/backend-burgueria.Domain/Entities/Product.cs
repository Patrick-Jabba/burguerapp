namespace backend_burgueria.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}