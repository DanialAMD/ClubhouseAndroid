using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class UserList : PagedClubhouseResponse
    {
        [JsonPropertyName("users")]
        public UserListItem[] Users { get; set; }
    }
}