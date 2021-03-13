using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class GetActionableNotificationsResponse : PagedClubhouseResponse
    {
        [JsonPropertyName("notifications")]
        public ActionableNotification[] Notifications { get; set; }
    }
}