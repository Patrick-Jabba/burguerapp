namespace backend_burgueria.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
