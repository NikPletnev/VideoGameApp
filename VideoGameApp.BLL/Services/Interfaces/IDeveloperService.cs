using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.BLL.Models;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.BLL.Services
{
    public interface IDeveloperService : IService<DeveloperModel>
    {
        Task AddGameAsync(Game game);
        Task RemoveGameAsync(Game game);
    }
}
