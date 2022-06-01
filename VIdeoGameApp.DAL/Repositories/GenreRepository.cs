using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly VideoGameAppContext _context;

        public GenreRepository(VideoGameAppContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Genre entity)
        {
            var genreId = (await _context.Genres.AddAsync(entity)).Entity.Id;
            await _context.SaveChangesAsync();
            return genreId;
        }

        public async Task AddGameAsync(Genre genre, Game game)
        {
            genre.Games.Add(game);
            game.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genre entity)
        {
            _context.Genres.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Genres.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(Genre genre, Game game)
        {
            genre.Games.Remove(game);
            game.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _context.Genres
                   .ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {

             return await _context.Genres.Where(g => g.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Genre entity, Genre model)
        {
            entity.Name = model.Name;
            entity.Games = model.Games;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
