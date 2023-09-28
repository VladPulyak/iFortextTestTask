using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using TestTask.Repositories.Interfaces;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetOrder()
        {
            var orderIdWithMaxCost = await _orderRepository.GetAll()
                .Select(q => new
                {
                    OrderId = q.Id,
                    Cost = q.Price * q.Quantity
                })
                .MaxAsync(q => q.OrderId);
            return await _orderRepository.GetById(orderIdWithMaxCost);
        }

        public Task<List<Order>> GetOrders()
        {
            return _orderRepository.GetAll().Where(q => q.Quantity > 10).ToListAsync();
        }
    }
}
