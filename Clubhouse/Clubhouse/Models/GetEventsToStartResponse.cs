using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class GetEventsToStartResponse : ClubhouseResponse
    {
        [JsonPropertyName("events")]
        public Event[] Events { get; set; }
    }
}