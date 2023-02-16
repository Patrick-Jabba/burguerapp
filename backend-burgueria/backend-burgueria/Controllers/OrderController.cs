using Microsoft.AspNetCore.Mvc;
using backend_burgueria.Models;
using backend_burgueria.Context;
using backend_burgueria.Domain.Interfaces.Services;

namespace backend_burgueria.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrdersList()
        {
            var orders = _orderService.GetAllOrders().ToList();

            return Ok(orders);
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            _orderService.CreateOrder(order);
            return Ok(order);
        }
    }
}