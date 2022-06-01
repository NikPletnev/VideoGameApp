using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public class DeveloperRepository : IRepository<Developer>
    {
        private readonly VideoGameAppContext _context;

        public DeveloperRepository(VideoGameAppContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Developer entity)
        {
            var developerId = (await _context.Developers.AddAsync(entity)).Entity.Id;
            await _context.SaveChangesAsync();
            return developerId;
        }

        public async Task Delete(Developer entity)
        {
            _context.Developers.Remove(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Developers.Remove(entity);
        }

        public async Task<List<Developer>> GetAll()
        {
            return await _context.Developers
                .ToListAsync();
        }

        public async Task<Developer> GetById(int id)
        {
            return await _context.Developers.Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(Developer entity, Developer model)
        {
            entity.Name = model.Name;
            entity.Games = model.Games;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
