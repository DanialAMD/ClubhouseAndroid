using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class ActivePingResponse : ClubhouseResponse
    {
        [JsonPropertyName("should_leave")]
        public bool ShouldLeave { get; set; }
    }
}