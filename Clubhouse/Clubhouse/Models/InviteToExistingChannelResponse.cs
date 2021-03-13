using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class InviteToExistingChannelResponse : ClubhouseResponse
    {
        [JsonPropertyName("notifications_enabled")]
        public bool NotificationsEnabled { get; set; }

        [JsonPropertyName("fallback_number_hash")]
        public string FallbackNumberHash { get; set; }

        [JsonPropertyName("fallback_message")]
        public string FallbackMessage { get; set; }
    }
}