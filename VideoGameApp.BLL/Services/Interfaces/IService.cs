namespace VideoGameApp.BLL.Services
{
    public interface IService<S>
    {
        Task<int> AddAsync(S entity);
        abstract Task UpdateAsync(S entity, int id);
        Task DeleteAsync(S entity);
        Task DeleteAsync(int id);
        Task<List<S>> GetAllAsync();
        Task<S> GetByIdAsync(int id);
    }
}
