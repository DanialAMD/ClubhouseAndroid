using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class MeResponse : ClubhouseResponse
    {
        [JsonPropertyName("has_unread_notifications")]
        public bool HasUnreadNotifications { get; set; }

        [JsonPropertyName("actionable_notifications_count")]
        public long ActionableNotificationsCount { get; set; }

        [JsonPropertyName("num_invites")]
        public long NumInvites { get; set; }

        [JsonPropertyName("auth_token")]
        public string AuthToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("notifications_enabled")]
        public bool NotificationsEnabled { get; set; }

        [JsonPropertyName("user_profile")]
        public UserProfileInfo UserProfile { get; set; }

        [JsonPropertyName("following_ids")]
        public long[] FollowingIds { get; set; }

        [JsonPropertyName("blocked_ids")]
        public long[] BlockedIds { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("feature_flags")]
        public string[] FeatureFlags { get; set; }
    }
}