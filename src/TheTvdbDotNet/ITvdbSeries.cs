using System.IO;
using System.Threading.Tasks;

namespace TheTvdbDotNet
{
    public interface ITvdbSeries
    {
        Task<SeriesEpisodes> GetEpisodesAsync(int seriesId, string page = null);

        Task<SeriesData> GetSeriesAsync(int seriesId);

        Task<SeriesEpisodes> QueryEpisodesAsync(
            int seriesId,
            string airedSeason = null,
            string airedEpisode = null,
            string imdbId = null,
            string dvdSeason = null,
            string dvdEpisode = null,
            string absoluteNumber = null,
            string firstAired = null,
            string page = null);

        Task<Stream> GetBannerAsnyc(Series series);
    }
}
