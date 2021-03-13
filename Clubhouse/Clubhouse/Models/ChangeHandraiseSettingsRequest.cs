using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class ChangeHandraiseSettingsRequest
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; set; }

        [JsonPropertyName("handraise_permission")]
        public int HandraisePermission { get; set; }
    }
}