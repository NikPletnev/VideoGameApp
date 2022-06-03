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
