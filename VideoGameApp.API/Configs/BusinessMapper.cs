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
            CreateMap<DeveloperModel, DeveloperWithoutGamesOutputModel>();

            CreateMap<GameModel, GameOutputModel>();
            CreateMap<GameModel, GameWithoutDeveloperOutputModel>();
            CreateMap<GameModel, GameWithoutGenresOutputModel>();

            CreateMap<GenreModel, GenreOutputModel>();
            CreateMap<GenreModel, GenreWithoutGamesOutputModel>();

        }
    }
}
