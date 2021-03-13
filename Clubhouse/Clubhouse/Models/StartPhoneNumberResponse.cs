using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class StartPhoneNumberResponse : ClubhouseResponse
    {
        [JsonPropertyName("is_blocked")]
        public bool IsBlocked { get; set; }
    }
}