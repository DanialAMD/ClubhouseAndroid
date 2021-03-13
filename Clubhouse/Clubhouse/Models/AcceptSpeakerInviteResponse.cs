using System;
using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class AcceptSpeakerInviteResponse : ClubhouseResponse, IPubnubConfig
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("pubnub_token")]
        public string PubnubToken { get; set; }

        [JsonPropertyName("pubnub_origin")]
        public string PubnubOrigin { get; set; }

        [JsonPropertyName("pubnub_heartbeat_value")]
        public int PubnubHeartbeatValue { get; set; }

        [JsonPropertyName("pubnub_heartbeat_interval")]
        public int PubnubHeartbeatInterval { get; set; }
    }
}