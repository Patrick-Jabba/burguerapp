using Microsoft.AspNetCore.Mvc;
using backend_burgueria.Models;
using backend_burgueria.Services;

namespace backend_burgueria.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("listproducts")]
        public IActionResult GetProducts()
        {
            var products = _productService.GetAllProduct().ToList();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.CreateProduct(product);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("GetByName")]
        public IActionResult GetProductByName(string name)
        {
            var products = _productService.GetProductByName(name);

            return Ok(products);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var dataBaseProduct = _productService.GetProductById(id);

            if (dataBaseProduct == null)
            {
                return NotFound();
            }

            dataBaseProduct.Name = product.Name;
            dataBaseProduct.Description = product.Description;
            dataBaseProduct.Price = product.Price;
            // dataBaseProduct.IngredientId = product.IngredientId;

            _productService.UpdateProduct(dataBaseProduct);
            return Ok(dataBaseProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dataBaseProduct = _productService.GetProductById(id);

            if (dataBaseProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}