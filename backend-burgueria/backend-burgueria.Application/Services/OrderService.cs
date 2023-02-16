using backend_burgueria.Domain.Interfaces.Repositories;
using backend_burgueria.Domain.Interfaces.Services;
using backend_burgueria.Models;

namespace backend_burgueria.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Create(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public IEnumerable<Order> GetOrderByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
