using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class EditEventRequest : EventRequest
    {
        [JsonPropertyName("user_ids")]
        public long[] UserIds { get; set; }

        [JsonPropertyName("club_id")]
        public long? ClubId { get; set; }

        [JsonPropertyName("is_member_only")]
        public bool IsMemberOnly { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("time_start_epoch")]
        public long TimeStartEpoch { get; set; }
    }
}