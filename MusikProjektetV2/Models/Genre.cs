using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusikProjektetV2.Models
{
	internal class Genre
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("genreName")]
		public string GenreName { get; set; }
	}
}
