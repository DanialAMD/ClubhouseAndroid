using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class ActionableNotification
    {
        [JsonPropertyName("actionable_notification_id")]
        public long ActionableNotificationId { get; set; }

        [JsonPropertyName("type")]
        public long Type { get; set; }

        [JsonPropertyName("time_created")]
        public DateTimeOffset TimeCreated { get; set; }

        [JsonPropertyName("user_profile")]
        public UserProfileInfo UserProfile { get; set; }

        [JsonPropertyName("club")]
        public Club Club { get; set; }
    }
}