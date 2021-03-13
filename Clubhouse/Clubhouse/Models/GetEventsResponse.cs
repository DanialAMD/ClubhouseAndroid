using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class GetEventsResponse : PagedClubhouseResponse
    {
        [JsonPropertyName("events")]
        public Event[] Events { get; set; }
    }
}