using Microsoft.AspNetCore.Mvc;
using backend_burgueria.Models;
using backend_burgueria.Context;

namespace backend_burgueria.Controllers
{
  [ApiController]
  [Route("ingredient")]
  public class IngredientController : ControllerBase
  {
    private readonly DataBaseContext _context;
    public IngredientController(DataBaseContext context)
    {
      _context = context;
    }

    // public IActionResult Create(Ingredient ingredient)
    // {
    //   _context.Add(ingredient);
    //   _context.SaveChanges();
    //   return Ok(ingredient);
    // }
  }
}