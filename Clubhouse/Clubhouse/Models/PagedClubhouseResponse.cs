using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class PagedClubhouseResponse : ClubhouseResponse
    {
        [JsonPropertyName("count")]
        public long Count { get; set; }

        [JsonPropertyName("next")]
        public int? Next { get; set; }

        [JsonPropertyName("previous")]
        public int? Previous { get; set; }
    }
}