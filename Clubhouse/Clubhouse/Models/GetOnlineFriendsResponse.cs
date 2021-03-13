using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class GetOnlineFriendsResponse
    {
        [JsonPropertyName("clubs")]
        public object[] Clubs { get; set; }

        [JsonPropertyName("users")]
        public OnlineUser[] Users { get; set; }
    }
}