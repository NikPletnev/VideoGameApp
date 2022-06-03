namespace VideoGameApp.API.Models
{
    public class GameOutputModel : GameInputModel
    {
        public DeveloperWithoutGamesOutputModel DeveloperStudio { get; set; }
        public List<GenreWithoutGamesOutputModel> Genres { get; set; }
    }
}
