using Microsoft.AspNetCore.Mvc;
using backend_burgueria.Models;
using backend_burgueria.Context;

namespace backend_burgueria.Controllers
{
  [ApiController]
  [Route("order")]
  public class OrderController : ControllerBase
  {
    private readonly DataBaseContext _context;

    public OrderController(DataBaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetOrdersList()
    {
        var ordersList = _context.Orders.ToList();

        return Ok(ordersList);
    }

    [HttpPost]
    public IActionResult CreateOrder(Order order)
    {
        _context.Add(order);
        _context.SaveChanges();
        return Ok(order);
    }
  }
}