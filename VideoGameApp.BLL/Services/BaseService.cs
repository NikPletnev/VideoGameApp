using AutoMapper;
using VideoGameApp.DAL.Repositories;

namespace VideoGameApp.BLL.Services
{
    public abstract class BaseService<S, R> : IService<S>
    {
        protected readonly IRepository<R> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IRepository<R> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(S entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Not enough data to create entity");
            }
            return await _repository.AddAsync(_mapper.Map<R>(entity));
        }

        public async Task DeleteAsync(S entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Not enough data to create entity");
            }
            await _repository.DeleteAsync(_mapper.Map<R>(entity));
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<S>> GetAllAsync()
        {
            return _mapper.Map<List<S>>(await _repository.GetAllAsync());
        }

        public async Task<S> GetByIdAsync(int id)
        {
            return _mapper.Map<S>(await _repository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(S entity, int id)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Not enough data to create entity");
            }
            var oldEntity = await _repository.GetByIdAsync(id);
            if (oldEntity == null)
            {
                throw new ArgumentNullException("Not enough data to create entity");
            }
            await _repository.UpdateAsync(oldEntity, _mapper.Map<R>(entity));
        }
    }
}
