using AutoMapper;
using VideoGameApp.BLL.Models;
using VideoGameApp.DAL.Entities;
using VideoGameApp.DAL.Repositories;

namespace VideoGameApp.BLL.Services
{
    public class DeveloperService : BaseService<DeveloperModel, Developer>, IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;
        public DeveloperService(IDeveloperRepository developerRepository, IMapper mapper) : base(developerRepository, mapper)
        {
            _developerRepository = developerRepository;
        }
        public async Task AddGameAsync(GameModel game, int developerId)
        {
            game.DeveloperStudio = new DeveloperModel() { Id = developerId};
            await _developerRepository.AddGameAsync(_mapper.Map<Game>(game));
        }

        public async Task RemoveGameAsync(GameModel game)
        {
            await _developerRepository.DeleteGameAsync(_mapper.Map<Game>(game));
        }
    }
}
