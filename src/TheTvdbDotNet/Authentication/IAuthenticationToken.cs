namespace TheTvdbDotNet.Authentication
{
    public interface IAuthenticationToken
    {
        Token Token { get; }

        string TokenString { get; }

        bool IsAuthenticated { get; }

        void SetToken(string token);
    }
}