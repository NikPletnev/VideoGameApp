using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGameApp.API.Models;
using VideoGameApp.BLL.Models;
using VideoGameApp.BLL.Services;

namespace VideoGameApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeveleperController : BaseController
    {
        private readonly  IDeveloperService _developerService;
        public DeveleperController(IMapper mapper, IDeveloperService developerService) : base(mapper)
        {
            _developerService = developerService;
        }

        [HttpPost]
        public async Task<ActionResult> AddDeveloper(DeveloperInputModel model)
        {
            await _developerService.AddAsync(_mapper.Map<DeveloperModel>(model));
            return Ok();
        }

        [HttpPatch("addGame")]
        public async Task<ActionResult> AddGameToDeveloper(GameInputModel model, int developerId)
        {
            await _developerService.AddGameAsync(_mapper.Map<GameModel>(model), developerId);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDeveloper(int id)
        {
            await _developerService.DeleteAsync(id);
            return Ok();
        }

        [HttpPatch("deleteGame")]
        public async Task<ActionResult> DeleteGameFromDeveloper(GameInputModel model)
        {
            await _developerService.RemoveGameAsync(_mapper.Map<GameModel>(model));
            return Ok();
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<DeveloperOutputModel>>> GetAll()
        {
            var developers = await _developerService.GetAllAsync();
            return Ok(_mapper.Map<List<DeveloperOutputModel>>(developers));
        }

        [HttpGet]
        public async Task<ActionResult<DeveloperOutputModel>> Get(int id)
        {
            var dev = await _developerService.GetByIdAsync(id);
            return Ok(_mapper.Map<DeveloperOutputModel>(dev));  
        }

        [HttpPatch("update")]
        public async Task<ActionResult> UpdateDeveloper(DelevoperUpdateInputModel dev, int id)
        {
            await _developerService.UpdateAsync(_mapper.Map<DeveloperModel>(dev), id);
            return Ok();
        }
    }
}
