using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Exceptions;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _set;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _set.AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            if (id < 0)
            {
                throw new InvalidArgumentExeption("Invalid argument");
            }

            var entity = await _set.FindAsync(id);

            if (entity == null)
            {
                throw new ObjectNotFoundException("Object not found");
            }

            return entity;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
