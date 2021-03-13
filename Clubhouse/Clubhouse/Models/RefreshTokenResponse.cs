using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class RefreshTokenResponse
    {
        [JsonPropertyName("refresh")]
        public string RefreshToken { get; set; }
      
        [JsonPropertyName("access")]
        public string AccessToken { get; set; }
    }
}