using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        Task AddGenreAsync(Genre genre, Game game);
        Task DeleteGenreAsync(Genre genre, Game game);
    }
}
