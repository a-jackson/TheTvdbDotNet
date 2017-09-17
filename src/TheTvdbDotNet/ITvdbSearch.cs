using System.Threading.Tasks;

namespace TheTvdbDotNet
{
    public interface ITvdbSearch
    {
        Task<SeriesSearch> SeriesSearchAsync(string name = null, string tvdbId = null, string zap2itId = null);
    }
}
