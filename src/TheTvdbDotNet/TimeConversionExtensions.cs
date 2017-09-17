using System;

namespace TheTvdbDotNet
{
    internal static class TimeConversionExtensions
    {
        private const long TimestampEpochTicks = 621355968000000000;
        private static readonly DateTime TimestampEpoch = new DateTime(TimestampEpochTicks, DateTimeKind.Utc);

        internal static long ToUnixTimestamp(this DateTime dateTime)
        {
            var inUtc = dateTime.ToUniversalTime();
            return (inUtc.Ticks - TimestampEpochTicks) / TimeSpan.TicksPerSecond;
        }

        internal static DateTime FromUnixTimestamp(this long timestamp)
        {
            return TimestampEpoch.AddSeconds(timestamp);
        }
    }
}
