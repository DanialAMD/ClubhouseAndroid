using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class UpdateBioRequest
    {
        [JsonPropertyName("bio")]
        public string Bio { get; set; }
    }
}