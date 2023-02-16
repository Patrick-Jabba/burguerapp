using backend_burgueria.Models;

namespace backend_burgueria.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetOrderByName(string name);
    }
}
