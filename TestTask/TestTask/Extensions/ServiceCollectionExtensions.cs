using TestTask.Models;
using TestTask.Repositories;
using TestTask.Repositories.Interfaces;
using TestTask.Services;
using TestTask.Services.Interfaces;

namespace TestTask.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
        }
    }
}
