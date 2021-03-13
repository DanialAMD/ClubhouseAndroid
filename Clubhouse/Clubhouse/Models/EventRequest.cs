using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class EventRequest
    {
        [JsonPropertyName("event_id")]
        public long? EventId { get; set; }

        [JsonPropertyName("event_hashid")]
        public string EventHashId { get; set; }
    }
}