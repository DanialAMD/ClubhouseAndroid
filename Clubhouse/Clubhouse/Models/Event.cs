using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class Event
    {
        [JsonPropertyName("event_id")]
        public long EventId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("time_start")]
        public DateTimeOffset TimeStart { get; set; }

        [JsonPropertyName("club")]
        public Club Club { get; set; }

        [JsonPropertyName("is_member_only")]
        public bool IsMemberOnly { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("hosts")]
        public EventHost[] Hosts { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("is_expired")]
        public bool IsExpired { get; set; }

        [JsonPropertyName("club_is_member")]
        public int? ClubIsMember { get; set; }

        [JsonPropertyName("club_is_follower")]
        public int? ClubIsFollower { get; set; }
    }
}