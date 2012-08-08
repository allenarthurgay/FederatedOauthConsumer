namespace Api.RestServiceHost.Services
{
    public interface IUserAuthTokenRepository
    {
        string GetUserTokenForPrincipalId(string principalId, string serviceName);
    }
}