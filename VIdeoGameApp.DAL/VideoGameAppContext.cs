using Microsoft.EntityFrameworkCore;
using VideoGameApp.DAL.Entities;

namespace VideoGameApp.DAL
{
    public class VideoGameAppContext : DbContext
    {
        public VideoGameAppContext(DbContextOptions<VideoGameAppContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Games");
            modelBuilder.Entity<Developer>().ToTable("Developers");
            modelBuilder.Entity<Genre>().ToTable("Genres");
        }
    }
}
