using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class OnlineUser
    {
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("photo_url")]
        public Uri PhotoUrl { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("last_active_minutes")]
        public long LastActiveMinutes { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("is_speaker")]
        public bool? IsSpeaker { get; set; }

        [JsonPropertyName("topic")]
        public string Topic { get; set; }
    }
}