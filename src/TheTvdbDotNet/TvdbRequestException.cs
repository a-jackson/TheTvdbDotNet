using System;

namespace TheTvdbDotNet
{
    public class TvdbRequestException : Exception
    {
        public TvdbRequestException(string message) : base(message)
        {
        }
    }
}
