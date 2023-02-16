using backend_burgueria.Context;
using backend_burgueria.Domain.Interfaces.Repositories;
using backend_burgueria.Models;

namespace backend_burgueria.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
