using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private readonly VideoGameAppContext _context;

        public GenreRepository(VideoGameAppContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Genre entity)
        {
            var genreId = (await _context.Genres.AddAsync(entity)).Entity.Id;
            await _context.SaveChangesAsync();
            return genreId;
        }

        public async Task Delete(Genre entity)
        {
            _context.Genres.Remove(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Genres.Remove(entity);
        }

        public async Task<List<Genre>> GetAll()
        {
            return await _context.Genres
                   .ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {

             return await _context.Genres.Where(g => g.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task Update(Genre entity, Genre model)
        {
            entity.Name = model.Name;
            entity.Games = model.Games;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
