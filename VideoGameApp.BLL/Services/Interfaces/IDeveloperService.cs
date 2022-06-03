using VideoGameApp.BLL.Models;

namespace VideoGameApp.BLL.Services
{
    public interface IDeveloperService : IService<DeveloperModel>
    {
        Task AddGameAsync(GameModel game, int developerId);
        Task RemoveGameAsync(GameModel game);
    }
}
