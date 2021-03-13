using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class CreateChannelResponse : ClubhouseResponse, IPubnubConfig
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

        [JsonPropertyName("is_handraise_enabled")]
        public bool IsHandraiseEnabled { get; set; }

        [JsonPropertyName("handraise_permission")]
        public HandraisePermission HandraisePermission { get; set; }

        [JsonPropertyName("is_club_member")]
        public bool IsClubMember { get; set; }

        [JsonPropertyName("is_club_admin")]
        public bool IsClubAdmin { get; set; }

        [JsonPropertyName("users")]
        public CurrentChannelUser[] Users { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("rtm_token")]
        public string RtmToken { get; set; }

        [JsonPropertyName("pubnub_token")]
        public string PubnubToken { get; set; }

        [JsonPropertyName("pubnub_origin")]
        public string PubnubOrigin { get; set; }

        [JsonPropertyName("pubnub_heartbeat_value")]
        public int PubnubHeartbeatValue { get; set; }

        [JsonPropertyName("pubnub_heartbeat_interval")]
        public int PubnubHeartbeatInterval { get; set; }

        [JsonPropertyName("pubnub_enable")]
        public bool PubnubEnable { get; set; }

        [JsonPropertyName("agora_native_mute")]
        public bool AgoraNativeMute { get; set; }
    }
}