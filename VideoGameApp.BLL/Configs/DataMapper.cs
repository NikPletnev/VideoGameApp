using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.BLL.Models;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.BLL.Configs
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<GameModel, Game>();
            CreateMap<Game, GameModel>();

            CreateMap<DeveloperModel, Developer>();
            CreateMap<Developer, DeveloperModel>();

            CreateMap<GenreModel, Genre>();
            CreateMap<Genre, GenreModel>();
        }
    }
}
