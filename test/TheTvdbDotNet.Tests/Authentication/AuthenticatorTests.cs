using NSubstitute;
using TheTvdbDotNet.Http;
using Xunit;

namespace TheTvdbDotNet.Authentication
{
    public class AuthenticatorTests
    {
        private const string ApiKey = "TestApiKey";
        private readonly IAuthenticationToken authenticationToken;
        private readonly ITvdbHttpClient httpClient;
        private readonly IAuthenticator authenticator;

        public AuthenticatorTests()
        {
            authenticationToken = Substitute.For<IAuthenticationToken>();
            httpClient = Substitute.For<ITvdbHttpClient>();
            authenticator = new Authenticator(httpClient, authenticationToken, ApiKey);
        }

        [Fact]
        public async void AttemptsAuthenticationWhenNecessary()
        {
            authenticationToken.IsAuthenticated.Returns(false);
            httpClient
                .PostResponseAsync<LoginResponse>("login", GetLoginRequest())
                .Returns(x => new LoginResponse() { Token = "JwtToken" });
            authenticationToken
                .When(x => x.SetToken("JwtToken"))
                .Do(x => authenticationToken.IsAuthenticated.Returns(true));

            await authenticator.AuthenticateIfNecessaryAsync();

            authenticationToken.Received(1).SetToken("JwtToken");
        }

        [Fact]
        public async void ValidatesTheTokenThatIsReceived()
        {
            authenticationToken.IsAuthenticated.Returns(false);
            httpClient
                .PostResponseAsync<LoginResponse>("login", GetLoginRequest())
                .Returns(x => new LoginResponse() { Token = "JwtToken" });

            var exception = await Assert.ThrowsAsync<TvdbRequestException>(
                () => authenticator.AuthenticateIfNecessaryAsync());

            Assert.Equal("Failed to authenticate", exception.Message);
        }

        [Fact]
        public async void DoesNotAuthenticateWhenNotNecessary()
        {
            authenticationToken.IsAuthenticated.Returns(true);

            await authenticator.AuthenticateIfNecessaryAsync();

            authenticationToken.DidNotReceive().SetToken(Arg.Any<string>());
            await httpClient.DidNotReceive().PostResponseAsync<LoginResponse>("login", GetLoginRequest());
        }

        private object GetLoginRequest() =>
            Arg.Is<LoginRequest>(x => x.ApiKey == ApiKey);
    }
}
