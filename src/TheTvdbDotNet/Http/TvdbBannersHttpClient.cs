using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TheTvdbDotNet.Http
{
    public class TvdbBannersHttpClient : ITvdbBannersHttpClient
    {
        private readonly HttpClient httpClient;

        public TvdbBannersHttpClient()
        {
            this.httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://www.thetvdb.com/banners/");
        }

        public Task<Stream> GetStreamAsync(Request request)
        {
            return httpClient.GetStreamAsync(request.BuildRequest());
        }
    }
}
