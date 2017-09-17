using System.Threading.Tasks;
using TheTvdbDotNet.Http;

namespace TheTvdbDotNet.Authentication
{
    public class Authenticator : IAuthenticator
    {
        private readonly ITvdbHttpClient httpClient;
        private readonly IAuthenticationToken authenticationToken;
        private readonly string apiKey;

        public Authenticator(ITvdbHttpClient httpClient, IAuthenticationToken authenticationToken, string apiKey)
        {
            this.httpClient = httpClient;
            this.authenticationToken = authenticationToken;
            this.apiKey = apiKey;
        }

        public Task AuthenticateIfNecessaryAsync()
        {
            if (authenticationToken.IsAuthenticated)
            {
                return Task.CompletedTask;
            }

            return AuthenticateAsync();
        }

        private async Task AuthenticateAsync()
        {
            var response = await LoginAsync().ConfigureAwait(false);
            SetToken(response.Token);
            httpClient.SetAuthorizationHeader(authenticationToken.TokenString);
        }

        private Task<LoginResponse> LoginAsync()
        {
            var loginRequest = new LoginRequest { ApiKey = apiKey };
            return httpClient.PostResponseAsync<LoginResponse>("login", loginRequest);
        }

        private void SetToken(string token)
        {
            authenticationToken.SetToken(token);
            if (!authenticationToken.IsAuthenticated)
            {
                throw new TvdbRequestException("Failed to authenticate");
            }
        }
    }
}
