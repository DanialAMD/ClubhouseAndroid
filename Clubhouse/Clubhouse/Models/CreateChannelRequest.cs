using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class CreateChannelRequest
    {
        [JsonPropertyName("is_social_mode")]
        public bool IsSocialMode { get; set; }

        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("club_id")]
        public long? ClubId { get; set; }

        [JsonPropertyName("user_ids")]
        public long[] UserIds { get; set; }

        [JsonPropertyName("event_id")]
        public long? EventId { get; set; }

        [JsonPropertyName("topic")]
        public string Topic { get; set; }
    }
}