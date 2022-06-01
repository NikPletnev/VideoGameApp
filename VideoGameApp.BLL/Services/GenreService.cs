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
    public class GenreService : BaseService<GenreModel, Genre>, IGenreService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGameRepository gameRepository, IGenreRepository genreRepository, IMapper mapper) : base(genreRepository, mapper)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }
        public async Task AddGameAsync(int genreId, int gameId)
        {
            var genreEntity = await _genreRepository.GetByIdAsync(genreId);
            var gameEntity = await _gameRepository.GetByIdAsync(gameId);

            await _genreRepository.AddGameAsync(genreEntity, gameEntity);
        }

        public async Task DeleteGameAsync(int genreId, int gameId)
        {
            var genreEntity = await _genreRepository.GetByIdAsync(genreId);
            var gameEntity = await _gameRepository.GetByIdAsync(gameId);

            await _genreRepository.DeleteGameAsync(genreEntity, gameEntity);
        }
    }
}
