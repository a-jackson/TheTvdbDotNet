using TheTvdbDotNet.Http;

namespace TheTvdbDotNet.Repositories
{
    public abstract class TvdbBaseRepository
    {
        private readonly IAuthenticatedTvdbHttpClient httpClient;

        public TvdbBaseRepository(IAuthenticatedTvdbHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        protected IAuthenticatedTvdbHttpClient HttpClient => httpClient;
    }
}
