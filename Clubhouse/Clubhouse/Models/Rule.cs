using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class Rule
    {
        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}