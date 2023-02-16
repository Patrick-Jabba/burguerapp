using backend_burgueria.Models;

namespace backend_burgueria.Services
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProduct();
        IEnumerable<Product> GetProductByName(string name);
    }
}