using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class JoinChannelRequest
    {
        [JsonPropertyName("channel")]
        public string Name { get; set; }
        [JsonPropertyName("attribution_source")]
        public string AttributionSource { get; set; }
        [JsonPropertyName("attribution_details")]
        public string AttributionDetails { get; set; }
    }
}