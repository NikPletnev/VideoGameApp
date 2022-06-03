using AutoMapper;
using VideoGameApp.API.Models;
using VideoGameApp.BLL.Models;

namespace VideoGameApp.API.Configs
{
    public class BusinessMapper : Profile
    {
        public BusinessMapper()
        {
            CreateMap<DeveloperInputModel, DeveloperModel>();
            CreateMap<GameInputModel, GameModel>();
            CreateMap<GenreInputModel, GenreModel>();

            CreateMap<DeveloperModel, DeveloperOutputModel>();
            CreateMap<GameModel, GameOutputModel>();
            CreateMap<GenreModel, GenreOutputModel>();
        }
    }
}
