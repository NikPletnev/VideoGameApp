namespace VideoGameApp.DAL.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        Task Update(T entity, T model);
        Task Delete(T entity);
        Task Delete(int id);
        Task<List<T>> GetAll();
    }
}
