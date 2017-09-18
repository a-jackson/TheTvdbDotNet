using System.IO;
using System.Threading.Tasks;
using TheTvdbDotNet.Authentication;

namespace TheTvdbDotNet.Http
{
    public class AuthenticatedTvdbHttpClient : IAuthenticatedTvdbHttpClient
    {
        private readonly ITvdbHttpClient httpClient;
        private readonly IAuthenticator authenticator;

        public AuthenticatedTvdbHttpClient(ITvdbHttpClient httpClient, IAuthenticator authenticator)
        {
            this.httpClient = httpClient;
            this.authenticator = authenticator;
        }

        public async Task<T> GetAsync<T>(Request request)
        {
            await authenticator.AuthenticateIfNecessaryAsync().ConfigureAwait(false);
            return await httpClient.GetResponseAsync<T>(request.BuildRequest()).ConfigureAwait(false);
        }

        public async Task<T> PostAsync<T>(Request request, object postData)
        {
            await authenticator.AuthenticateIfNecessaryAsync().ConfigureAwait(false);
            return await httpClient.PostResponseAsync<T>(request.BuildRequest(), postData).ConfigureAwait(false);
        }

        public async Task<Stream> GetStreamAsync(Request request)
        {
            await authenticator.AuthenticateIfNecessaryAsync().ConfigureAwait(false);
            return await httpClient.GetStreamAsync(request.BuildRequest()).ConfigureAwait(false);
        }
    }
}
