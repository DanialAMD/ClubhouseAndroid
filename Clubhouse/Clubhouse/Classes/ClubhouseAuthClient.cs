using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ClubhouseDotNet
{
    public class ClubhouseAuthClient
    {
        private readonly HttpClient _client;

        public ClubhouseAuthClient()
        {
            _client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            })
            {
                BaseAddress = new Uri("https://www.clubhouseapi.com/")
            };

            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("Accept-Language", "en-JP;q=1, ja-JP;q=0.9");

            _client.DefaultRequestHeaders.Add(HeaderNames.ChLanguages, "en-JP,ja-JP");
            _client.DefaultRequestHeaders.Add(HeaderNames.ChLocale, "en-JP");
            _client.DefaultRequestHeaders.Add(HeaderNames.ChAppBuild, Constants.API_BUILD_ID);
            _client.DefaultRequestHeaders.Add(HeaderNames.ChAppVersion, Constants.API_BUILD_VERSION);
            _client.DefaultRequestHeaders.Add("User-Agent", Constants.API_UA);
            _client.DefaultRequestHeaders.Add("Connection", "close");
        }

        public async Task<StartPhoneNumberResponse> StartPhoneNumberAuthAsync(string phoneNumber)
        {
            var response = await _client.PostAsJsonAsync("/api/start_phone_number_auth", new PhoneNumberAuthRequest
            {
                PhoneNumber = phoneNumber
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<StartPhoneNumberResponse>();
        }

        public async Task<StartPhoneNumberResponse> CallPhoneNumberAuthAsync(string phoneNumber)
        {
            var response = await _client.PostAsJsonAsync("/api/call_phone_number_auth", new PhoneNumberAuthRequest
            {
                PhoneNumber = phoneNumber
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<StartPhoneNumberResponse>();
        }

        public async Task<StartPhoneNumberResponse> ResendPhoneNumberAuthAsync(string phoneNumber)
        {
            var response = await _client.PostAsJsonAsync("/api/resend_phone_number_auth", new PhoneNumberAuthRequest
            {
                PhoneNumber = phoneNumber
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<StartPhoneNumberResponse>();
        }

        public async Task<CompletePhoneNumberAuthResponse> CompletePhoneNumberAuthAsync(string phoneNumber, string verificationCode)
        {
            var response = await _client.PostAsJsonAsync("/api/complete_phone_number_auth", new
            {
                phone_number = phoneNumber,
                verification_code = verificationCode
            });

            var deviceId = response.Headers.GetValues("CH-DeviceId");
            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<CompletePhoneNumberAuthResponse>();
        }
    }
}