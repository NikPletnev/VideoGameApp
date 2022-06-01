using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApp.BLL.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameModel> Games { get; set; }
    }
}
