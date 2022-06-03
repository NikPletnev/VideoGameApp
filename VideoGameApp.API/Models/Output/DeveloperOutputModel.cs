namespace VideoGameApp.API.Models
{
    public class DeveloperOutputModel : DeveloperInputModel
    {
        public List<GameWithoutDeveloperOutputModel> Games { get; set; }
    }
}
