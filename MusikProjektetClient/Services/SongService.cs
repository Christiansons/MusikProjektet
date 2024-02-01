using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusikProjektetClient.Services
{
	public class SongService
	{
		private HttpClient _client;

        public SongService(HttpClient client)
        {
            _client = client;
        }
		public SongService() : this(new HttpClient()) { }

        public async Task AddNewSong()
        {
			await Console.Out.WriteAsync("Enter title: ");
			string title = Console.ReadLine();

			await Console.Out.WriteAsync("Enter Content: ");
			string content = Console.ReadLine();

		}
    }
}
