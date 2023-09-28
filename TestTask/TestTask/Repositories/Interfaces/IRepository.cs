namespace TestTask.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        public IQueryable<TEntity> GetAll();

        public Task<TEntity> GetById(int id);
    }
}
