using Microsoft.EntityFrameworkCore;
using MusikProjektetV2.Data;
using MusikProjektetV2.Handlers;

namespace MusikProjektetV2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddAuthorization();
			builder.Services.AddEndpointsApiExplorer();
			string connectionString = builder.Configuration.GetConnectionString("myConnection");
			builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString)); 
			var app = builder.Build();
			app.UseHttpsRedirection();
			app.UseAuthorization();

			app.MapPost("/song/{artistId}/{genreId}", SongHandler.AddSong);
			
			app.MapGet("/user/{id}/song", SongHandler.GetAllSongConnectedToUser);

			app.MapPost("/user/{userId}/song/{songId}", UserHandler.ConnectUserToSong);
			app.Run();
		}
	}
}
