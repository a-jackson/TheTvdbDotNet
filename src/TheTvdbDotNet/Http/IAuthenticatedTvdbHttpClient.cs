using System.IO;
using System.Threading.Tasks;

namespace TheTvdbDotNet.Http
{
    public interface IAuthenticatedTvdbHttpClient
    {
        Task<T> GetAsync<T>(Request request);

        Task<T> PostAsync<T>(Request request, object postData);

        Task<Stream> GetStreamAsync(Request request);
    }
}
