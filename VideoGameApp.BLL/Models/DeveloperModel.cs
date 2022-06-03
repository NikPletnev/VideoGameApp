namespace VideoGameApp.BLL.Models
{
    public class DeveloperModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GameModel> Games { get; set; }
    }
}
