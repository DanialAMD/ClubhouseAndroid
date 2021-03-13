using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class CreateEventResponse : ClubhouseResponse
    {
        [JsonPropertyName("event_id")]
        public long EventId { get; set; }
    }
}