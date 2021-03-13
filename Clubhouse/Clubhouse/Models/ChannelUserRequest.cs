using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class ChannelUserRequest
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; }
        
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
    }
}