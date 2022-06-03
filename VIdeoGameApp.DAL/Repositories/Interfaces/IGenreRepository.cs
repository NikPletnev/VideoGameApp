using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task AddGameAsync(Genre genre, Game game);
        Task DeleteGameAsync(Genre genre, Game game);
    }
}
