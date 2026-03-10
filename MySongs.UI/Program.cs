using MySongs.Mock;
using MySongs.Repository.Interfaces;
using MySongs.Repository.Repositories;
using MySongs.Services.Interfaces;
using MySongs.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace MySongs.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MySongsDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            builder.Services.AddScoped<ISongRepository, SongRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<ISongTagRepository, SongTagRepository>();
            builder.Services.AddScoped<IRecommendationRepository, RecommendationRepository>();
            builder.Services.AddScoped<IListeningHistoryRepository, ListeningHistoryRepository>();

            // Services
            builder.Services.AddScoped<ISongService, SongService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<ISongTagService, SongTagService>();
            builder.Services.AddScoped<IRecommendationService, RecommendationService>();
            builder.Services.AddScoped<IListeningHistoryService, ListeningHistoryService>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IContext, MySongsDbContext>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}