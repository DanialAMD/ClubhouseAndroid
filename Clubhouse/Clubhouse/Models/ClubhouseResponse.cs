using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class ClubhouseResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
    }
}