using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ClubhouseDotNet
{
    public class ClubhouseClient 
    {
        private readonly HttpClient _client;

        public ClubhouseClient(string authToken)
        {
            _client = new HttpClient(new AuthenticatedHttpClientHandler(
                () => Task.FromResult(authToken),
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
                }))
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
            //_client.DefaultRequestHeaders.Add("Cookie", $"__cfduid={secrets.token_hex(21)}{random.randint(1, 9)}");
        }

        public async Task<MeResponse> MeAsync(bool returnFollowingIds=false, bool returnBlockedIds=false, string timezoneIdentifier="Asia/Tokyo")
        {
            var response = await _client.PostAsJsonAsync("/api/me", new MeRequest
            {
                ReturnFollowingIds = returnFollowingIds,
                ReturnBlockedIds = returnBlockedIds,
                TimezoneIdentifier = timezoneIdentifier
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<MeResponse>();
        }


        public async Task<ClubhouseResponse> UpdateBio(string bio)
        {
            var response = await _client.PostAsJsonAsync("/api/update_bio", new UpdateBioRequest {Bio = bio});

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<GetEventsResponse> GetEventsAsync(bool isFiltered = true, int page = 1, int pageSize = 25)
        {
            var response = await _client.GetAsync(
                $"/api/get_events?is_filtered={(isFiltered ? "true" : "false")}&page_size={pageSize}&page={page}");

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<GetEventsResponse>();
        }

        public async Task<GetEventsToStartResponse> GetEventsToStartAsync()
        {
            var response = await _client.GetAsync("/api/get_events_to_start");

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<GetEventsToStartResponse>();
        }

        public async Task<GetEventResponse> GetEventAsync(long? eventId = null, string eventHashId = null)
        {
            if (eventId == null && eventHashId == null)
                throw new ArgumentException($"Either {nameof(eventId)} or {nameof(eventHashId)} should be specified", nameof(eventId));

            var response = await _client.PostAsJsonAsync("/api/get_event", new EventRequest
            {
                EventId = eventId,
                EventHashId = eventHashId
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<GetEventResponse>();
        }

        public async Task<CreateEventResponse> CreateEventAsync(string name, string description, DateTimeOffset startTime, long[] userIds, long? clubId = null, bool isMemberOnly = false)
        {
            var response = await _client.PostAsJsonAsync("/api/create_event",
                new EditEventRequest
                {
                    UserIds = userIds, 
                    ClubId = clubId,
                    IsMemberOnly = isMemberOnly,
                    Name = name,
                    Description = description,
                    TimeStartEpoch = startTime.ToUnixTimeSeconds(),
                    EventId = default,
                    EventHashId = default
                });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<CreateEventResponse>();
        }

        public async Task<ClubhouseResponse> EditEventAsync(string name, string description, DateTimeOffset startTime, long[] userIds, long? eventId = null, string eventHashId = null, long? clubId = null, bool isMemberOnly = false)
        {
            if (eventId == null && eventHashId == null)
                throw new ArgumentException($"Either {nameof(eventId)} or {nameof(eventHashId)} should be specified", nameof(eventId));

            var response = await _client.PostAsJsonAsync("/api/edit_event",
                new EditEventRequest
                {
                    UserIds = userIds, 
                    ClubId = clubId,
                    IsMemberOnly = isMemberOnly,
                    Name = name,
                    Description = description,
                    TimeStartEpoch = startTime.ToUnixTimeSeconds(),
                    EventId = eventId,
                    EventHashId = eventHashId
                });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ClubhouseResponse> DeleteEventAsync(long? eventId = null, string eventHashId = null)
        {
            if (eventId == null && eventHashId == null)
                throw new ArgumentException($"Either {nameof(eventId)} or {nameof(eventHashId)} should be specified", nameof(eventId));

            var response = await _client.PostAsJsonAsync("/api/delete_event",
                new EventRequest
                {
                    EventId = eventId,
                    EventHashId = eventHashId
                });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ChannelList> GetChannelsAsync()
        {
            var response = await _client.GetAsync("/api/get_channels");

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ChannelList>();
        }

        public async Task<GetChannelResponse> GetChannelAsync(string name, long? channelId = null)
        {
            var response = await _client.PostAsJsonAsync("/api/get_channel", new ChannelRequest()
            {
                Name = name,
                ChannelId = channelId
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<GetChannelResponse>();
        }

        public async Task<CreateChannelResponse> CreateChannelAsync(string topic = null, bool isSocialMode = false, bool isPrivate = false, long? clubId = null, long[] userIds = null, long? eventId = null)
        {
            var response = await _client.PostAsJsonAsync("/api/create_channel", new CreateChannelRequest
            {
                IsSocialMode = isSocialMode,
                IsPrivate = isPrivate,
                ClubId = clubId,
                UserIds = userIds ?? Array.Empty<long>(),
                EventId = eventId,
                Topic = topic
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<CreateChannelResponse>();
        }

        public async Task<JoinChannelResponse> JoinChannelAsync(string name, string attributionSource = "feed", string attributionDetails="eyJpc19leHBsb3JlIjpmYWxzZSwicmFuayI6MX0=")
        {
            var response = await _client.PostAsJsonAsync("/api/join_channel", new JoinChannelRequest
            {
                Name = name,
                AttributionSource = attributionSource,
                AttributionDetails = attributionDetails
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<JoinChannelResponse>();
        }

        public async Task<ClubhouseResponse> LeaveChannelAsync(string name, long? channelId = null)
        {
            var response = await _client.PostAsJsonAsync("/api/leave_channel", new ChannelRequest
            {
                Name = name, ChannelId = channelId
            });

            return await response.EnsureSuccessStatusCode()
                    .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }
        
        public async Task<ClubhouseResponse> MakeChannelPublicAsync(string name, long? channelId = null)
        {
            var response = await _client.PostAsJsonAsync("/api/make_channel_public", new ChannelRequest
            {
                Name = name, ChannelId = channelId
            });

            return await response.EnsureSuccessStatusCode()
                    .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }
        
        public async Task<ClubhouseResponse> MakeChannelSocialAsync(string name, long? channelId = null)
        {
            var response = await _client.PostAsJsonAsync("/api/make_channel_social", new ChannelRequest
            {
                Name = name, ChannelId = channelId
            });

            return await response.EnsureSuccessStatusCode()
                    .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }
        
        public async Task<ClubhouseResponse> EndChannelAsync(string name, long? channelId = null)
        {
            var response = await _client.PostAsJsonAsync("/api/end_channel", new ChannelRequest
            {
                Name = name, 
                ChannelId = channelId
            });

            return await response.EnsureSuccessStatusCode()
                    .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ActivePingResponse> ActivePingAsync(string name, long? channelId = null)
        {
            var response = await _client.PostAsJsonAsync("/api/active_ping", new ChannelRequest
            {
                Name = name,
                ChannelId = channelId
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ActivePingResponse>();
        }

        public async Task<ClubhouseResponse> InviteToExistingChannelAsync(string channel, long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/invite_to_existing_channel", new ChannelUserRequest {Channel = channel, UserId = userId});

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<InviteToExistingChannelResponse>();
        }

        public async Task<ClubhouseResponse> InviteToNewChannelAsync(string channel, long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/invite_to_new_channel", new ChannelUserRequest {Channel = channel, UserId = userId});

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<InviteToNewChannelResponse>();
        }

        public async Task<ClubhouseResponse> InviteSpeakerAsync(string channel, long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/invite_speaker", new ChannelUserRequest {Channel = channel, UserId = userId});

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ClubhouseResponse> UnInviteSpeakerAsync(string channel, long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/uninvite_speaker", new ChannelUserRequest {Channel = channel, UserId = userId});

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ClubhouseResponse> MuteSpeakerAsync(string channel, long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/mute_speaker", new ChannelUserRequest {Channel = channel, UserId = userId});

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }
        
        public async Task<ClubhouseResponse> MakeModeratorAsync(string channel, long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/make_moderator", new ChannelUserRequest {Channel = channel, UserId = userId});

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<AcceptSpeakerInviteResponse> AcceptSpeakerInviteAsync(string channel, long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/accept_speaker_invite", new ChannelUserRequest {Channel = channel, UserId = userId});

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<AcceptSpeakerInviteResponse>();
        }

        public async Task<ClubhouseResponse> AudienceReplyAsync(string name, bool raiseHands)
        {
            var response = await _client.PostAsJsonAsync("/api/audience_reply", new 
            {
                channel = name,
                raise_hands = raiseHands,
                unraise_hands = !raiseHands
            });
            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ClubhouseResponse> RejectSpeakerInviteAsync(string channel, long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/reject_speaker_invite", new ChannelUserRequest {Channel = channel, UserId = userId});

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ClubhouseResponse> BlockFromChannelAsync(string channel, long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/block_from_channel", new ChannelUserRequest {Channel = channel, UserId = userId});

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ClubhouseResponse> FollowAsync(long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/follow", new
            {
                source = 4,
                source_topic_id = default(long?),
                user_ids = Array.Empty<long>(),
                user_id = userId
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ClubhouseResponse> UnFollowAsync(long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/unfollow", new UserRequest
            {
                UserId = userId
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ClubhouseResponse> BlockAsync(long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/block", new UserRequest
            {
                UserId = userId
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<ClubhouseResponse> UnBlockAsync(long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/unblock", new UserRequest
            {
                UserId = userId
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<GetNotificationsResponse> GetNotificationsAsync(int page = 1, int pageSize = 50)
        {
            var response = await _client.GetAsync($"/api/get_notifications?page_size={pageSize}&page={page}");

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<GetNotificationsResponse>();
        }

        public async Task<ClubhouseResponse> GetActionableNotificationsAsync()
        {
            var response = await _client.GetAsync("/api/get_actionable_notifications");

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<GetActionableNotificationsResponse>();
        }

        public async Task<RefreshTokenResponse> RefreshTokenAsync(string refreshToken)
        {
            var response = await _client.PostAsJsonAsync("/api/refresh_token", new
            {
                refresh = refreshToken
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<RefreshTokenResponse>();
        }

        public async Task<UserList> GetFollowersAsync(long userId, int page = 1, int pageSize = 50)
        {
            var response = await _client.GetAsync($"/api/get_followers?user_id={userId}&page_size={pageSize}&page={page}");

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<UserList>();
        }

        public async Task<UserList> GetFollowingAsync(long userId, int page = 1, int pageSize = 50)
        {
            var response = await _client.GetAsync($"/api/get_following?user_id={userId}&page_size={pageSize}&page={page}");

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<UserList>();
        }

        public async Task<UserList> GetMutualFollowsAsync(long userId, int page = 1, int pageSize = 50)
        {
            var response = await _client.GetAsync($"/api/get_mutual_follows?user_id={userId}&page_size={pageSize}&page={page}");

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<UserList>();
        }

        public async Task<GetOnlineFriendsResponse> GetOnlineFriendsAsync()
        {
            var response = await _client.PostAsJsonAsync("/api/get_online_friends", new { });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<GetOnlineFriendsResponse>();
        }

        public async Task<GetProfileResponse> GetProfileAsync(long userId)
        {
            var response = await _client.PostAsJsonAsync("/api/get_profile", new UserRequest
            {
                UserId = userId
            });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<GetProfileResponse>();
        }

        public async Task<ClubhouseResponse> ChangeHandraiseSettingsAsync(string channel, bool isEnabled=true, HandraisePermission handraisePermission=HandraisePermission.Everyone)
        {
            var response = await _client.PostAsJsonAsync("/api/change_handraise_settings",
                new ChangeHandraiseSettingsRequest
                {
                    Channel = channel,
                    IsEnabled = isEnabled,
                    HandraisePermission = (int) handraisePermission
                });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<ClubhouseResponse>();
        }

        public async Task<GetReleaseNotesResponse> GetReleaseNotesAsync()
        {
            var response = await _client.PostAsJsonAsync("/api/get_release_notes", new { });

            return await response.EnsureSuccessStatusCode()
                .Content.ReadFromJsonAsync<GetReleaseNotesResponse>();
        }
    }
}