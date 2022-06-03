using VideoGameApp.BLL.Models;

namespace VideoGameApp.BLL.Services
{
    public interface IGenreService : IService<GenreModel>
    {
        Task AddGameAsync(int genreId, int gameId);
        Task DeleteGameAsync(int genreId, int gameId);
    }
}
