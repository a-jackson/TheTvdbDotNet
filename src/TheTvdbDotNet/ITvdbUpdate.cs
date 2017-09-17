using System;
using System.Threading.Tasks;

namespace TheTvdbDotNet
{
    public interface ITvdbUpdate
    {
        Task<UpdateData> GetUpdatesAsync(DateTime fromTime, DateTime? toTime = default(DateTime?));
    }
}
