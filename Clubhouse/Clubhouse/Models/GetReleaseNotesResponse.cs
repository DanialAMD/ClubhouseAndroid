using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class GetReleaseNotesResponse
    {
        [JsonPropertyName("should_display")]
        public bool ShouldDisplay { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }
}