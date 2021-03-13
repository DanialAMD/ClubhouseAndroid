using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class Notification
    {
        [JsonPropertyName("notification_id")]
        public long NotificationId { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("time_created")]
        public DateTimeOffset TimeCreated { get; set; }

        [JsonPropertyName("is_unread")]
        public bool IsUnread { get; set; }

        [JsonPropertyName("user_profile")]
        public UserProfile UserProfile { get; set; }

        [JsonPropertyName("event_id")]
        public long? EventId { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("user_profiles")]
        public UserProfileInfo[] UserProfiles { get; set; }

        [JsonPropertyName("count")]
        public long? Count { get; set; }
    }
}