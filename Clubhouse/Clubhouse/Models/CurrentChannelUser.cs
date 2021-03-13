using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class CurrentChannelUser
    {
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("photo_url")]
        public Uri PhotoUrl { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("skintone")]
        public long Skintone { get; set; }

        [JsonPropertyName("is_new")]
        public bool IsNew { get; set; }

        [JsonPropertyName("is_speaker")]
        public bool IsSpeaker { get; set; }

        [JsonPropertyName("is_moderator")]
        public bool IsModerator { get; set; }

        [JsonPropertyName("time_joined_as_speaker")]
        public DateTimeOffset? TimeJoinedAsSpeaker { get; set; }

        [JsonPropertyName("is_followed_by_speaker")]
        public bool IsFollowedBySpeaker { get; set; }

        [JsonPropertyName("is_invited_as_speaker")]
        public bool IsInvitedAsSpeaker { get; set; }
    }
}