using System.Text.Json.Serialization;
using MusikProjektetV2.Data;
using MusikProjektetV2.Models;

namespace MusikProjektetV2.Models.Dtos
{
	public class SongDto
	{
		[JsonPropertyName("songTitle")]
		public string SongTitle { get; set; }
	}
}
