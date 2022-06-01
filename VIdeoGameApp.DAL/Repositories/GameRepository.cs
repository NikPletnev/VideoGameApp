using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private readonly VideoGameAppContext _context;

        public GameRepository(VideoGameAppContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Game entity)
        {
            var gameId = (await _context.Games.AddAsync(entity)).Entity.Id;
            await _context.SaveChangesAsync();
            return gameId;
        }

        public async Task Delete(Game entity)
        {
            _context.Games.Remove(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Games.Remove(entity);
        }

        public async Task<List<Game>> GetAll()
        {
            return await _context.Games
                .ToListAsync();
        }

        public async Task<Game> GetById(int id)
        {
            return await _context.Games.Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(Game entity, Game model)
        {
            entity.Name = model.Name;
            entity.DeveloperStudio = model.DeveloperStudio;
            entity.Genres = model.Genres;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
