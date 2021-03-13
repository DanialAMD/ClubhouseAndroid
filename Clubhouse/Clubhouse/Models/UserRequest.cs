using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class UserRequest
    {
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
    }
}