using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class GetChannelResponse : ClubhouseResponse
    {
        [JsonPropertyName("creator_user_profile_id")]
        public long CreatorUserProfileId { get; set; }

        [JsonPropertyName("channel_id")]
        public long ChannelId { get; set; }

        [JsonPropertyName("channel")]
        public string Name { get; set; }

        [JsonPropertyName("topic")]
        public string Topic { get; set; }

        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("is_social_mode")]
        public bool IsSocialMode { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("feature_flags")]
        public string[] FeatureFlags { get; set; }

        [JsonPropertyName("club")]
        public object Club { get; set; }

        [JsonPropertyName("club_name")]
        public object ClubName { get; set; }

        [JsonPropertyName("club_id")]
        public object ClubId { get; set; }

        [JsonPropertyName("welcome_for_user_profile")]
        public object WelcomeForUserProfile { get; set; }

        [JsonPropertyName("is_handraise_enabled")]
        public bool IsHandraiseEnabled { get; set; }

        [JsonPropertyName("handraise_permission")]
        public long HandraisePermission { get; set; }

        [JsonPropertyName("is_club_member")]
        public bool IsClubMember { get; set; }

        [JsonPropertyName("is_club_admin")]
        public bool IsClubAdmin { get; set; }

        [JsonPropertyName("users")]
        public CurrentChannelUser[] Users { get; set; }

        [JsonPropertyName("should_leave")]
        public bool ShouldLeave { get; set; }
    }
}