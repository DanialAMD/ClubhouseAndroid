using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class UserProfile
    {
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("displayname")]
        public string DisplayName { get; set; }

        [JsonPropertyName("photo_url")]
        public Uri PhotoUrl { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("twitter")]
        public string Twitter { get; set; }

        [JsonPropertyName("instagram")]
        public string Instagram { get; set; }

        [JsonPropertyName("num_followers")]
        public long NumFollowers { get; set; }

        [JsonPropertyName("num_following")]
        public long NumFollowing { get; set; }

        [JsonPropertyName("time_created")]
        public DateTimeOffset TimeCreated { get; set; }

        [JsonPropertyName("follows_me")]
        public bool FollowsMe { get; set; }

        [JsonPropertyName("is_blocked_by_network")]
        public bool IsBlockedByNetwork { get; set; }

        [JsonPropertyName("mutual_follows_count")]
        public long MutualFollowsCount { get; set; }

        [JsonPropertyName("mutual_follows")]
        public UserProfileInfo[] MutualFollows { get; set; }

        [JsonPropertyName("notification_type")]
        public long NotificationType { get; set; }

        [JsonPropertyName("invited_by_user_profile")]
        public UserProfileInfo InvitedByUserProfile { get; set; }

        [JsonPropertyName("clubs")]
        public Club[] Clubs { get; set; }
    }
}