using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
        Task AddGameAsync(Game game);
        Task DeleteGameAsync(Game game);
    }
}
