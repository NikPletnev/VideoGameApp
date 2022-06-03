using VideoGameApp.BLL.Models;

namespace VideoGameApp.BLL.Services
{
    public interface IDeveloperService : IService<DeveloperModel>
    {
        Task AddGameAsync(GameModel game);
        Task RemoveGameAsync(GameModel game);
    }
}
