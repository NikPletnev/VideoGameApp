using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGameApp.API.Models;
using VideoGameApp.BLL.Models;
using VideoGameApp.BLL.Services;

namespace VideoGameApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : BaseController
    {
        private readonly IGenreService _genreService;
        public GenreController(IMapper mapper, IGenreService genreService) : base(mapper)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<ActionResult> AddGenre(GenreInputModel model)
        {
            await _genreService.AddAsync(_mapper.Map<GenreModel>(model)); ;
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<GenreOutputModel>>> GetAll()
        {
            var genres = await _genreService.GetAllAsync();
            return Ok(_mapper.Map<List<GenreOutputModel>>(genres));
        }

        [HttpGet]
        public async Task<ActionResult<GenreOutputModel>> Get(int id)
        {
            var genre = await _genreService.GetByIdAsync(id);
            return Ok(_mapper.Map<GenreOutputModel>(genre));
        }

        [HttpPatch("update")]
        public async Task<ActionResult> Update(GenreUpdateInputModel genre, int id)
        {
            await _genreService.UpdateAsync(_mapper.Map<GenreModel>(genre), id);
            return Ok();
        }

        [HttpPatch("addGame")]
        public async Task<ActionResult> AddGameToGenre(int genreId, int gameId)
        {
            await _genreService.AddGameAsync(genreId, gameId);
            return Ok();
        }

        [HttpPatch("deleteGame")]
        public async Task<ActionResult> DeleteGameFromGenre(int genreId, int gameId)
        {
            await _genreService.DeleteGameAsync(genreId, gameId);
            return Ok();
        }
    }
}
