using System.IO;
using System.Threading.Tasks;
using TheTvdbDotNet.Http;

namespace TheTvdbDotNet.Repositories
{
    public class TvdbSeriesRepository : TvdbBaseRepository, ITvdbSeries
    {
        private readonly ITvdbBannersHttpClient bannersHttpClient;

        public TvdbSeriesRepository(IAuthenticatedTvdbHttpClient httpClient, ITvdbBannersHttpClient bannersHttpClient)
            : base(httpClient)
        {
            this.bannersHttpClient = bannersHttpClient;
        }

        public Task<SeriesData> GetSeriesAsync(int seriesId)
        {
            var request = new Request("series/{id}", seriesId);
            return HttpClient.GetAsync<SeriesData>(request);
        }

        public Task<SeriesEpisodes> GetEpisodesAsync(int seriesId, string page = null)
        {
            var request = new Request("series/{id}/episodes", seriesId);
            request.AddCriteriaIfNotNull("page", page);
            return HttpClient.GetAsync<SeriesEpisodes>(request);
        }

        public Task<SeriesEpisodes> QueryEpisodesAsync(
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
            return HttpClient.GetAsync<SeriesEpisodes>(request);
        }

        public Task<Stream> GetBannerAsnyc(Series series)
        {
            var request = new Request(series.Banner);
            return bannersHttpClient.GetStreamAsync(request);
        }
    }
}
