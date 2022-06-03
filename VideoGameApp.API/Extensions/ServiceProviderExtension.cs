using Microsoft.EntityFrameworkCore;
using VideoGameApp.BLL.Services;
using VideoGameApp.DAL;
using VideoGameApp.DAL.Entities;
using VideoGameApp.DAL.Repositories;

namespace VideoGameApp.API.Extensions
{
    public static class ServiceProviderExtension
    {
        public static void RegisterVideoGameAppServices(this IServiceCollection services)
        {
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGenreService, GenreService>();

        }

        public static void RegisterVideoGameAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }

        public static void AddConnectionString(this IServiceCollection services)
        {
            services.AddDbContext<VideoGameAppContext>(
                options =>
                {
                    options.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VideoGameApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        });
        }

    }
}
