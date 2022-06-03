namespace VideoGameApp.API.Models
{
    public class GameWithoutDeveloperOutputModel : GameInputModel
    {
        public List<GenreWithoutGamesOutputModel> Genres { get; set; }
    }
}
