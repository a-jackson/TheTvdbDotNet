using System.IO;
using System.Threading.Tasks;

namespace TheTvdbDotNet.Http
{
    public interface ITvdbHttpClient
    {
        Task<T> GetResponseAsync<T>(string uri);

        Task<T> PostResponseAsync<T>(string uri, object postData);

        Task<Stream> GetStreamAsync(string uri);

        void SetAuthorizationHeader(string token);
    }
}
