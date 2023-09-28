using TestTask.Data;
using TestTask.Models;

namespace TestTask.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
