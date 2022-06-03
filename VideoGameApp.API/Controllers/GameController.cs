using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGameApp.API.Models;
using VideoGameApp.BLL.Models;
using VideoGameApp.BLL.Services;

namespace VideoGameApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;
        public GameController(IMapper mapper, IGameService gameService) : base(mapper)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult> AddGame(GameInputModel model)
        {
            await _gameService.AddAsync(_mapper.Map<GameModel>(model));;
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGame(int id)
        {
            await _gameService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<GameOutputModel>>> GetAll()
        {
            var games = await _gameService.GetAllAsync();
            return Ok(_mapper.Map<List<GameOutputModel>>(games));
        }

        [HttpGet]
        public async Task<ActionResult<GameOutputModel>> Get(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            return Ok(_mapper.Map<GameOutputModel>(game));
        }

        [HttpPatch("update")]
        public async Task<ActionResult> Update(GameUpdateInputModel game, int id)
        {
            await _gameService.UpdateAsync(_mapper.Map<GameModel>(game), id);
            return Ok();
        }

        [HttpPatch("addGenre")]
        public async Task<ActionResult> AddGenreToGame(int genreId, int gameId)
        {
            await _gameService.AddGenreAsync(genreId, gameId);
            return Ok();
        }

        [HttpPatch("deleteGenre")]
        public async Task<ActionResult> DeleteGenreFromGame(int genreId, int gameId)
        {
            await _gameService.DeleteGenreAsync(genreId, gameId);
            return Ok();
        }
    }
}
