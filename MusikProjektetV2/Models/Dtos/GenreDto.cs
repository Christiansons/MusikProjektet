using System.Text.Json.Serialization;

namespace MusikProjektetV2.Models.Dtos
{
    public class GenreDto
    {
        [JsonPropertyName("GenreName")]
        public string GenreName { get; set; }

        [JsonPropertyName("UserId")]
        public int UserId { get; set; }
    }
}
