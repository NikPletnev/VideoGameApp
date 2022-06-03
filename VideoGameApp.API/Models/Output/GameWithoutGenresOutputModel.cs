namespace VideoGameApp.API.Models
{
    public class GameWithoutGenresOutputModel : GameInputModel
    {
        public DeveloperWithoutGamesOutputModel DeveloperStudio { get; set; }
    }
}
