using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class Channel
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
        public Club Club { get; set; }

        [JsonPropertyName("club_name")]
        public string ClubName { get; set; }

        [JsonPropertyName("club_id")]
        public long? ClubId { get; set; }

        [JsonPropertyName("welcome_for_user_profile")]
        public object WelcomeForUserProfile { get; set; }

        [JsonPropertyName("num_other")]
        public long NumOther { get; set; }

        [JsonPropertyName("has_blocked_speakers")]
        public bool HasBlockedSpeakers { get; set; }

        [JsonPropertyName("is_explore_channel")]
        public bool IsExploreChannel { get; set; }

        [JsonPropertyName("num_speakers")]
        public long NumSpeakers { get; set; }

        [JsonPropertyName("num_all")]
        public long NumAll { get; set; }

        [JsonPropertyName("users")]
        public ChannelUser[] Users { get; set; }
    }
}