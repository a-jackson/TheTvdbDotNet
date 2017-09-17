using System;
using Xunit;

namespace TheTvdbDotNet.Authentication
{
    public class AuthenticationTokenTests
    {
        private AuthenticationToken authenticationToken;

        public AuthenticationTokenTests()
        {
            authenticationToken = new AuthenticationToken();
        }

        [Fact]
        public void DecodeTest()
        {
            var token =
                "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE0OTkzMzEwNzcsImlkIjoiVFYgU29" +
                "ydGVyIiwib3JpZ19pYXQiOjE0OTkyNDQ2Nzd9.SnMEWThZyqDUsWWaEJaQShOMl62GTCG3SCRz7H" +
                "aT-JMPjNL0wT1bYeqRVUMbKqttBAoJXu44r1-l3WS6VeoGnKZSwSd5QD0ErNt0GhVQxzAYGdXYQL" +
                "PQI7Wj3ByptiYKiuEwF-fG_uyAiCP1O5sQP_w0RlpOcEBBzdWLmsyzXLHaRaZb9dS9e86skuXB3K" +
                "OS4zF57QOWcIKKOfHNSzU7eMzIwJX3SztbEad4nrUvNoyHTHTHD9xJLKuJrDZjjrSGm9q1kaU-1O" +
                "eBVLneH2xIq8zWBFAB7PVeQRVa-jWuVtFitZ0zZFLwhrmojWAs9iIknHxvP1_oSLpsx9LrNk9ZjA";

            authenticationToken.SetToken(token);

            Assert.Equal(
                new DateTime(2017, 7, 5, 8, 51, 17, DateTimeKind.Utc),
                authenticationToken.Token.OriginalIssuedAtDateTime);
            Assert.Equal(
                new DateTime(2017, 7, 6, 8, 51, 17, DateTimeKind.Utc),
                authenticationToken.Token.ExpiryDateTime);
        }
    }
}
