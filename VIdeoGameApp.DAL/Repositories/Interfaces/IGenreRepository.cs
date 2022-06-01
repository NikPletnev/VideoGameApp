using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task AddGameAsync(Genre genre, Game game);
        Task DeleteGameAsync(Genre genre, Game game);
    }
}
