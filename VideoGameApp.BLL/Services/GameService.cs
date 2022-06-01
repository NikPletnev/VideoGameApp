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
    public class GameService : BaseService<GameModel, Game>, IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        public GameService(IGameRepository gameRepository, IGenreRepository genreRepository, IMapper mapper) : base(gameRepository, mapper)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }
        public async Task AddGenreAsync(int genreId, int gameId)
        {
            var genreEntity = await _genreRepository.GetByIdAsync(genreId);
            var gameEntity = await _gameRepository.GetByIdAsync(gameId);

            await _gameRepository.AddGenreAsync(genreEntity, gameEntity);
        }

        public async Task DeleteGenreAsync(int genreId, int gameId)
        {
            var genreEntity = await _genreRepository.GetByIdAsync(genreId);
            var gameEntity = await _gameRepository.GetByIdAsync(gameId);

            await _gameRepository.DeleteGenreAsync(genreEntity, gameEntity);
        }
    }
}
