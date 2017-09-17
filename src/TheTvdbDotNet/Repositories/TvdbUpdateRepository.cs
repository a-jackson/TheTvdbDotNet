using System;
using System.Threading.Tasks;
using TheTvdbDotNet.Http;

namespace TheTvdbDotNet.Repositories
{
    public class TvdbUpdateRepository : TvdbBaseRepository, ITvdbUpdate
    {
        public TvdbUpdateRepository(IAuthenticatedTvdbHttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<UpdateData> GetUpdatesAsync(DateTime fromTime, DateTime? toTime = null)
        {
            var request = new Request("/updated/query");
            request.AddCriteria("fromTime", fromTime.ToUnixTimestamp().ToString());
            request.AddCriteriaIfNotNull("toTime", toTime?.ToUnixTimestamp().ToString());
            return await HttpClient.GetAsync<UpdateData>(request).ConfigureAwait(false);
        }
    }
}
