namespace VideoGameApp.BLL.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameModel> Games { get; set; }
    }
}
