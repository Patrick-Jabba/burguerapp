using Microsoft.AspNetCore.Mvc;
using backend_burgueria.Models;
using backend_burgueria.Context;

namespace backend_burgueria.Controllers
{
  [ApiController]
  [Route("product")]
  public class ProductController : ControllerBase
  {
    private readonly DataBaseContext _context;
    public ProductController(DataBaseContext context)
    {
      _context = context;
    }

    [HttpGet("listproducts")]
    public IActionResult GetProducts()
    {
      var lista = _context.Products.ToList();
      
      return Ok(lista);
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
      _context.Add(product);
      _context.SaveChanges();
      return Ok(product);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
      var product = _context.Products.Find(id);

      if (product == null)
      {
        return NotFound();
      }

      return Ok(product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
      var dataBaseProduct = _context.Products.Find(id);

      if(dataBaseProduct == null)
      {
        return NotFound();
      }

      dataBaseProduct.Name = product.Name;
      dataBaseProduct.Description = product.Description;
      dataBaseProduct.Price = product.Price;
      dataBaseProduct.IngredientId = product.IngredientId;

      _context.Products.Update(dataBaseProduct);
      _context.SaveChanges();
      return Ok(dataBaseProduct);
    }
  }
}