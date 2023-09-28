using Microsoft.EntityFrameworkCore;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Repositories.Interfaces;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Order> _orderRepository;

        public UserService(IRepository<User> userRepository, IRepository<Order> orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public async Task<User> GetUser()
        {
            var userIdWithMaxOrders = _orderRepository.GetAll()
                .GroupBy(q => q.UserId)
                .Select(q => new
                {
                    UserId = q.Key,
                    Count = q.Count()
                })
                .Max(q => q.UserId);
            return await _userRepository.GetById(userIdWithMaxOrders);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetAll().Where(q => q.Status == UserStatus.Inactive).ToListAsync();
        }
    }
}
