using TestTask.Data;
using TestTask.Models;

namespace TestTask.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
