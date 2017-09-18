using System.IO;
using System.Threading.Tasks;

namespace TheTvdbDotNet.Http
{
    public interface ITvdbBannersHttpClient
    {
        Task<Stream> GetStreamAsync(Request request);
    }
}