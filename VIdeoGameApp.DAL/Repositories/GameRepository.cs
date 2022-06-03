using Microsoft.EntityFrameworkCore;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly VideoGameAppContext _context;

        public GameRepository(VideoGameAppContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Game entity)
        {
            var gameId = (await _context.Games.AddAsync(entity)).Entity.Id;
            await _context.SaveChangesAsync();
            return gameId;
        }

        public async Task AddGenreAsync(Genre genre, Game game)
        {
            genre.Games.Add(game);
            game.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Game entity)
        {
            _context.Games.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Games.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(Genre genre, Game game)
        {
            genre.Games.Remove(game);
            game.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games
                .ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _context.Games.Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Game entity, Game model)
        {
            entity.Name = model.Name;
            entity.DeveloperStudio = model.DeveloperStudio;
            entity.Genres = model.Genres;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
