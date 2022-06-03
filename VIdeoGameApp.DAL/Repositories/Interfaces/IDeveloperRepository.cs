using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
        Task AddGameAsync(Game game);
        Task DeleteGameAsync(Game game);
    }
}
