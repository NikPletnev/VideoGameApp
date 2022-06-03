namespace VideoGameApp.API.Models
{
    public class GenreOutputModel : GenreInputModel
    {
        public List<GameWithoutGenresOutputModel> Games { get; set; }
    }
}
