using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TheTvdbDotNet.Http
{
    public class TvdbHttpClientTests
    {
        [Fact]
        public async Task GetDataTest()
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent("\"test-data\"", Encoding.UTF8, "application/json"),
            };
            var responseHandler = new FakeHttpMessageHandler(response);
            var client = new HttpClient(responseHandler);
            var tvdbClient = new TvdbHttpClient(client);
            var data = await tvdbClient.GetResponseAsync<string>(string.Empty);
            Assert.Equal("test-data", data);
        }


        [Fact]
        public async void ErrorResponse()
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
            {
                Content = new StringContent("{\"Error\":\"This is an error\"}", Encoding.UTF8, "application/json"),
            };
            var responseHandler = new FakeHttpMessageHandler(response);
            var client = new HttpClient(responseHandler);
            var tvdbClient = new TvdbHttpClient(client);

            var exception = await Assert.ThrowsAsync<TvdbRequestException>(
                async () => await tvdbClient.GetResponseAsync<string>(string.Empty));
            Assert.Equal("This is an error", exception.Message);
        }
    }
}
