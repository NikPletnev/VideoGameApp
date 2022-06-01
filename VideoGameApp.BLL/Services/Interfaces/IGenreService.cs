using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.BLL.Models;

namespace VideoGameApp.BLL.Services
{
    public interface IGenreService : IService<GenreModel>
    {
        Task AddGameAsync(int genreId, int gameId);
        Task DeleteGameAsync(int genreId, int gameId);
    }
}
