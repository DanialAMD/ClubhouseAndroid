using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class GetEventResponse : ClubhouseResponse
    {
        [JsonPropertyName("event")]
        public Event Event { get; set; }
    }
}