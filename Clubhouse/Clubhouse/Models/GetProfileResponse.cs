using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class GetProfileResponse : ClubhouseResponse
    {
        [JsonPropertyName("user_profile")]
        public UserProfile UserProfile { get; set; }
    }
}