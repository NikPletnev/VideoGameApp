namespace VideoGameApp.DAL.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Developer DeveloperStudio { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
