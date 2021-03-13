using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class MeRequest
    {
        [JsonPropertyName("return_following_ids")]
        public bool ReturnFollowingIds { get; set; }

        [JsonPropertyName("return_blocked_ids")]
        public bool ReturnBlockedIds { get; set; }

        [JsonPropertyName("timezone_identifier")]
        public string TimezoneIdentifier { get; set; }
    }
}