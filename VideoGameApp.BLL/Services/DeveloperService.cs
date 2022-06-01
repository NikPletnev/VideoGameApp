using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.BLL.Models;
using VideoGameApp.DAL.Entities;
using VideoGameApp.DAL.Repositories;

namespace VideoGameApp.BLL.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IRepository<Developer> _repository;
        private readonly IMapper _mapper;

        public DeveloperService(IRepository<Developer> developerRepository, IMapper mapper)
        {
            _repository = developerRepository;
            _mapper = mapper;
        }
        public async Task<int> AddAsync(DeveloperModel entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("Not enough data to create entity");
            }
            return await _repository.AddAsync(_mapper.Map<Developer>(entity));
        }

        public Task AddGameAsync(Game game)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(DeveloperModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Not enough data to create entity");
            }
            await _repository.DeleteAsync(_mapper.Map<Developer>(entity));
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<DeveloperModel>> GetAllAsync()
        {
            return _mapper.Map<List<DeveloperModel>>(await _repository.GetAllAsync());
        }

        public async Task<DeveloperModel> GetByIdAsync(int id)
        {
            return _mapper.Map<DeveloperModel>(await _repository.GetByIdAsync(id));
        }

        public Task RemoveGameAsync(Game game)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(DeveloperModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Not enough data to create entity");
            }
            var oldEntity = await _repository.GetByIdAsync(entity.Id);
            if (oldEntity == null)
            {
                throw new ArgumentNullException("Not enough data to create entity");
            }
            await _repository.UpdateAsync(oldEntity, _mapper.Map<Developer>(entity));
        }

    }
}
