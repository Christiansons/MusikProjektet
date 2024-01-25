using Microsoft.EntityFrameworkCore;
using MusikProjektetV2.Data;

namespace MusikProjektetV2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			string connectionString = builder.Configuration.GetConnectionString("myConnection");
			builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
			// Add services to the container.
			builder.Services.AddAuthorization();


			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.Run();
		}
	}
}
