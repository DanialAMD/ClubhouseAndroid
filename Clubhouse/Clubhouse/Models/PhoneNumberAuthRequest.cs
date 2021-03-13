using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class PhoneNumberAuthRequest
    {
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
    }
}