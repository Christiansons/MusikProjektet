using Microsoft.EntityFrameworkCore;
using MusikProjektetV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusikProjektetV2.Data
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Artist> Artists { get; set; }
		public DbSet<Song> Songs { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
	}
}
