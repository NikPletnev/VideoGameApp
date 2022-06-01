namespace VideoGameApp.DAL.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity, T model);
        Task DeleteAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
