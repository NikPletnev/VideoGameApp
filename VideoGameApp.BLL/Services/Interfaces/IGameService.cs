using VideoGameApp.BLL.Models;

namespace VideoGameApp.BLL.Services
{
    public interface IGameService : IService<GameModel>
    {
        Task AddGenreAsync(int genreId, int gameId);
        Task DeleteGenreAsync(int genreId, int gameId);
    }
}
