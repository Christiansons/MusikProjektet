using MusikProjektetV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusikProjektetV2.Models
{
	internal class Song
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("songTitle")]
		public string SongTitle { get; set; }

		[JsonPropertyName("genre")]
		public virtual Genre Genre { get; set; }

		[JsonPropertyName("artist")]
		public virtual Artist Artist { get; set; }
	}
}
