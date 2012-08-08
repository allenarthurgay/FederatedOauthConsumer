using System.Net;

namespace Api.RestServiceHost.Services
{
    public interface IAuthenticatedYammerRequestFactory
    {
        HttpWebRequest CreateAuthenticatedRequest(string principalId, string url);
    }
}