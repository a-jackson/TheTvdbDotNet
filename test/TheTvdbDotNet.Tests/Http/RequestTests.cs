using Xunit;

namespace TheTvdbDotNet.Http
{
    public class RequestTests
    {
        [Fact]
        public void ResourceRequest()
        {
            var request = new Request("test");
            Assert.Equal("test", request.BuildRequest());
        }

        [Fact]
        public void ResourceNumberIdRequest()
        {
            var request = new Request("test/{id}", 2);
            Assert.Equal("test/2", request.BuildRequest());
        }

        [Fact]
        public void ResourceStringIdRequest()
        {
            var request = new Request("test/{id}", "id");
            Assert.Equal("test/id", request.BuildRequest());
        }

        [Fact]
        public void ResourceCriteraRequest()
        {
            var request = new Request("test");
            request.AddCriteria("name", "value");
            request.AddCriteria("othername", "newvalue");
            Assert.Equal("test?name=value&othername=newvalue", request.BuildRequest());
        }

        [Fact]
        public void ResourceIdCriteraRequest()
        {
            var request = new Request("test/{id}", 2);
            request.AddCriteria("name", "value");
            request.AddCriteria("othername", "newvalue");
            Assert.Equal("test/2?name=value&othername=newvalue", request.BuildRequest());
        }
    }
}
