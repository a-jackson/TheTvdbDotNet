using System.Threading.Tasks;
using TheTvdbDotNet.Http;

namespace TheTvdbDotNet.Repositories
{
    public class TvdbSeriesRepository : TvdbBaseRepository, ITvdbSeries
    {
        public TvdbSeriesRepository(IAuthenticatedTvdbHttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<SeriesData> GetSeriesAsync(int seriesId)
        {
            var request = new Request("series/{id}", seriesId);
            return await HttpClient.GetAsync<SeriesData>(request).ConfigureAwait(false);
        }

        public async Task<SeriesEpisodes> GetEpisodesAsync(int seriesId, string page = null)
        {
            var request = new Request("series/{id}/episodes", seriesId);
            request.AddCriteriaIfNotNull("page", page);
            return await HttpClient.GetAsync<SeriesEpisodes>(request).ConfigureAwait(false);
        }

        public async Task<SeriesEpisodes> QueryEpisodesAsync(
            int seriesId,
            string airedSeason = null,
            string airedEpisode = null,
            string imdbId = null,
            string dvdSeason = null,
            string dvdEpisode = null,
            string absoluteNumber = null,
            string firstAired = null,
            string page = null)
        {
            var request = new Request("series/{id}/episodes/query", seriesId);
            request.AddCriteriaIfNotNull("airedSeason", airedSeason);
            request.AddCriteriaIfNotNull("airedEpisode", airedEpisode);
            request.AddCriteriaIfNotNull("imdbId", imdbId);
            request.AddCriteriaIfNotNull("dvdSeason", dvdSeason);
            request.AddCriteriaIfNotNull("dvdEpisode", dvdEpisode);
            request.AddCriteriaIfNotNull("absoluteNumber", absoluteNumber);
            request.AddCriteriaIfNotNull("firstAired", firstAired);
            request.AddCriteriaIfNotNull("page", page);
            return await HttpClient.GetAsync<SeriesEpisodes>(request).ConfigureAwait(false);
        }
    }
}
