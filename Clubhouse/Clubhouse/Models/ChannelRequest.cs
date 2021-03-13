using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class ChannelRequest
    {
        [JsonPropertyName("channel")]
        public string Name { get; set; }
        [JsonPropertyName("channel_id")]
        public long? ChannelId { get; set; }
    }
}