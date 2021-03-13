using System.Text.Json.Serialization;

namespace ClubhouseDotNet
{
    public class CompletePhoneNumberAuthResponse : ClubhouseResponse
    {
        [JsonPropertyName("is_verified")]
        public bool IsVerified { get; set; }

        [JsonPropertyName("number_of_attempts_remaining")]
        public int? NumberOfAttemptsRemaining { get; set; }

        [JsonPropertyName("user_profile")]
        public UserProfile UserProfile { get; set; }

        [JsonPropertyName("auth_token")]
        public string AuthToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("is_waitlisted")]
        public bool? IsWaitlisted { get; set; }

        [JsonPropertyName("is_onboarding")]
        public bool? IsOnboarding { get; set; }
    }
}