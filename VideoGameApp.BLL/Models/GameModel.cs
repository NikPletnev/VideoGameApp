using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApp.BLL.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeveloperModel DeveloperStudio { get; set; }
        public List<GenreModel> Genres { get; set; }
    }
}
