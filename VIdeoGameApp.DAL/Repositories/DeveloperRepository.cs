using Microsoft.EntityFrameworkCore;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly VideoGameAppContext _context;

        public DeveloperRepository(VideoGameAppContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Developer entity)
        {
            var developerId = (await _context.Developers.AddAsync(entity)).Entity.Id;
            await _context.SaveChangesAsync();
            return developerId;
        }

        public async Task AddGameAsync(Game game)
        {
            var developer = await _context.Developers.Where(d => d.Id == game.DeveloperStudio.Id).FirstOrDefaultAsync();
            developer.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Developer entity)
        {
            _context.Developers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Developers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(Game game)
        {
            var developer = await _context.Developers.Where(d => d.Id == game.DeveloperStudio.Id).FirstOrDefaultAsync();
            developer.Games.Remove(game);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Developer>> GetAllAsync()
        {
            return await _context.Developers
                .ToListAsync();
        }

        public async Task<Developer> GetByIdAsync(int id)
        {
            return await _context.Developers.Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Developer entity, Developer model)
        {
            entity.Name = model.Name;
            entity.Games = model.Games;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
