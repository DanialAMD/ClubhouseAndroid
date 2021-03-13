using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ClubhouseDotNet
{
    public class AuthenticatedHttpClientHandler : DelegatingHandler
    {
        private readonly Func<Task<string>> _getToken;

        public AuthenticatedHttpClientHandler(Func<Task<string>> getToken, HttpMessageHandler innerHandler = null)
            : base(innerHandler ?? new HttpClientHandler())
        {
            _getToken = getToken ?? throw new ArgumentNullException(nameof(getToken));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _getToken().ConfigureAwait(false);
            request.Headers.Authorization = new AuthenticationHeaderValue("Token", token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}