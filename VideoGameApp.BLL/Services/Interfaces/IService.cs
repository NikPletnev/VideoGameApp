using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApp.BLL.Services
{
    public interface IService<S>
    {
        Task<int> AddAsync(S entity);
        abstract Task UpdateAsync(S entity, int id);
        Task DeleteAsync(S entity);
        Task DeleteAsync(int id);
        Task<List<S>> GetAllAsync();
        Task<S> GetByIdAsync(int id);
    }
}
