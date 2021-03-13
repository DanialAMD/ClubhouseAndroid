using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class GetNotificationsResponse : PagedClubhouseResponse
    {
        [JsonPropertyName("notifications")]
        public Notification[] Notifications { get; set; }

        [JsonPropertyName("disabled")]
        public bool Disabled { get; set; }
    }
}